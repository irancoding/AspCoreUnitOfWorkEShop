using WebUI.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Contracts;
using Infrastructure.Result;
using Infrastructure.Services;
using Infrastructure.Repositories;
using Infrastructure.Database;
using Domain.Enum;
using Application.ViewModels;
using WebUI.Controllers;
using Infrastructure.Utils;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        public AuthController(ISharedRepository sharedRepository) : base(sharedRepository)
        {
        }

        [HttpGet]
        public IActionResult _Sign(string returnUrl = null)
        {
            var modelVm = new SignVm()
            {
                returnUrl = returnUrl
            };

            return PartialView("Partials/_Sign", modelVm);
        }

        [HttpGet]
        public IActionResult _SignUp(string returnUrl = null)
        {
            var modelVm = new SignUpVm()
            {
                returnUrl = returnUrl
            };

            return PartialView("Partials/_SignUp", modelVm);
        }

        [HttpPost]
        public async Task<CustomJsonResult> SignUp(SignUpVm modelVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userAvail = await _sharedRepository._userManager().Users.FirstOrDefaultAsync(u => u.MobileNumber == modelVm.MobileNumber);

                    if (userAvail != null)
                    {
                        return CustomJsonResultMethods.Json(false, "شما قبلا ثبت نام کرده اید . جهت ورود اقدام نمایید", "", modelVm.returnUrl);
                    }

                    var smsCode = _sharedRepository._httpContextAccessor().HttpContext.Session.GetString("SMSCode");
                    if (string.IsNullOrEmpty(smsCode))
                    {
                        return CustomJsonResultMethods.Json(true, "مجددا درخواست ارسال پیامک کنید", "", smsCode);
                    }

                    if (smsCode!=modelVm.SMSCode)
                    {
                        return CustomJsonResultMethods.Json(false, "کد وارد شده صحیح نمی باشد", "", smsCode);
                    }

                    modelVm.UserName = modelVm.MobileNumber;

                    var user = new AppUser { UserName = modelVm.UserName, MobileNumber = modelVm.MobileNumber, FullName = modelVm.FullName, Status = UserStatusEnum.Active, LockoutEnabled = false, IsEnable = true };
                    var result = await _sharedRepository._userManager().CreateAsync(user, modelVm.Password);
                    var userCreated = await _sharedRepository._userManager().FindByNameAsync(modelVm.UserName);

                    //افزودن نقش کاربر
                    result = await _sharedRepository._roleManager().CreateAsync(new AppRole { Name = EnumRoleMain.User.ToString() });
                    result = await _sharedRepository._roleManager().CreateAsync(new AppRole { Name = "Free" });
                    result = await _sharedRepository._userManager().AddToRoleAsync(user, EnumRoleMain.User.ToString());

                    if (_sharedRepository._userManager().Users.Count() == 1)//اگر هیچ کاربری تاکنون ثبت نشده است
                    {
                        //افزودن نقش ادمین
                        result = await _sharedRepository._roleManager().CreateAsync(new AppRole { Name = EnumRoleMain.Admin.ToString() });
                        result = await _sharedRepository._userManager().AddToRoleAsync(user, EnumRoleMain.Admin.ToString());


                        modelVm.returnUrl ??= Url.Content("~/Admin/Dashboard");
                    }
                    else//ثبت نام های بعدی به عنوان کاربر هستند
                    {
                        modelVm.returnUrl ??= Url.Content("~/User/Dashboard");
                    }

                    if (result.Succeeded)
                    {
                        await _sharedRepository._signInManager().SignInAsync(user, isPersistent: true);
                        //_UserRepository.ChangeUserStatus(userCreated.Id, UserStatusEnum.Wait);
                        //var modelItemSMSData = new SMSData()
                        //{
                        //    PatternParameter_1 = modelVm.FullName,
                        //    PatternParameter_2 = "7starExpert.com",
                        //    PatternParameter_3 = modelVm.MobileNumber,
                        //    SMSType = Domain.Enums.EnumSMSType.SMS_IR_SignUp
                        //};
                        //await _SMSService.SendSMSAsync_VerifyMethod_SMS_IR(modelItemSMSData);
                        return CustomJsonResultMethods.Json(true, "کاربر گرامی، ثبت نام کاربری شما پس از بررسی اطلاعات هویتی فعال خواهد شد", "", modelVm.returnUrl);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }

                        return CustomJsonResultMethods.Json(false, "خطایی رخ داده است");
                    }
                }
                else
                {
                    return CustomJsonResultMethods.Json(false, "فیلدهای اجباری وارد شوند");
                }                
            }
            catch (Exception ex)
            {

                return CustomJsonResultMethods.Json(false, ex.Message);
            }            
        }
        [HttpPost]
        public CustomJsonResult SignUp_SendSMS(SignUpVm modelVm)
        {
            try
            {
                ModelState.Remove("SMSCode");
                if (ModelState.IsValid)
                {
                    //ایجاد کد اس ام اس
                    var smsCode = _sharedRepository._httpContextAccessor().HttpContext.Session.GetString("SMSCode");
                    if (!string.IsNullOrEmpty(smsCode))
                    {
                        return CustomJsonResultMethods.Json(true, "قبلا پیامکی برای شما ارسال شده است", "", smsCode);
                    }

                    smsCode = NumberUtils.RandomNumber(4000, 9999).ToString();
                    _sharedRepository._httpContextAccessor().HttpContext.Session.SetString("SMSCode", smsCode);
                    return CustomJsonResultMethods.Json(true, "پیامکی حاوی کد به شماره موبایل شما ارسال شد", "", smsCode);
                }

                return CustomJsonResultMethods.Json(false, "فیلدهای اجباری وارد شود");
            }
            catch (Exception ex)
            {
                return CustomJsonResultMethods.Json(false, ex.Message);
            }
        }

        [HttpPost]
        public CustomJsonResult SignUp_ResendSMS()
        {
            try
            {
                //ایجاد کد اس ام اس
                string smsCode = NumberUtils.RandomNumber(4000, 9999).ToString();
                _sharedRepository._httpContextAccessor().HttpContext.Session.SetString("SMSCode", smsCode);
                return CustomJsonResultMethods.Json(true, "پیامکی حاوی کد به شماره موبایل شما ارسال شد", "", smsCode);
            }
            catch (Exception ex)
            {
                return CustomJsonResultMethods.Json(false, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> _SignIn(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);// Clear the existing external cookie to ensure a clean login process

            SignInVm modelVm = new SignInVm()
            {
                returnUrl = returnUrl,
            };
            //افزودن به جدول نقش
            //var role = new AppRole { Name = ((EnumPermission)(EnumPermission.Free)).ToString(), HasChildren = false };
            //await _sharedRepository._roleManager().CreateAsync(role);
            return PartialView("Partials/_SignIn", modelVm);
        }

        [HttpPost]
        public async Task<CustomJsonResult> SignIn(SignInVm modelVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _sharedRepository._userManager().Users.FirstOrDefaultAsync(u => u.MobileNumber == modelVm.MobileNumber);

                    if (user == null)
                    {
                        return CustomJsonResultMethods.Json(false, "نام کاربری یا رمز عبور شما اشتباه است", "", modelVm.returnUrl);
                    }

                    switch (user.Status)
                    {
                        case UserStatusEnum.InActive:
                            return CustomJsonResultMethods.Json(false, "حساب کاربری شما غیر فعال است", "", modelVm.returnUrl);
                        case UserStatusEnum.Wait:
                            return CustomJsonResultMethods.Json(false, "کاربر گرامی، ثبت نام کاربری شما پس از بررسی اطلاعات هویتی فعال خواهد شد", "", modelVm.returnUrl);
                    }

                    var result1 = await _sharedRepository._roleManager().CreateAsync(new AppRole { Name = EnumRoleMain.User.ToString() });
                    result1 = await _sharedRepository._userManager().AddToRoleAsync(user, EnumRoleMain.User.ToString());

                    modelVm.Email = user.Email;

                    var result = await _sharedRepository._signInManager().PasswordSignInAsync(user, modelVm.Password, modelVm.RememberMe, lockoutOnFailure: false);
                    if (!result.Succeeded)
                    {
                        return CustomJsonResultMethods.Json(false, "رمز عبور اشتباه است", "", modelVm.returnUrl);
                    }

                    if (modelVm.Role == EnumRoleMain.Admin || await _sharedRepository._userManager().IsInRoleAsync(user, EnumRoleMain.Admin.ToString()))
                    {
                        modelVm.returnUrl ??= Url.Content("~/Admin/Dashboard");
                    }
                    else
                    {
                        switch (modelVm.Role)
                        {
                            default:
                                modelVm.returnUrl ??= Url.Content("~/User/Dashboard");
                                break;
                        }
                    }

                    //افزودن آیدی کاربر به سشن
                    //_httpContextAccessor.HttpContext.Session.SetString("UserId", user.Id.ToString());

                    return CustomJsonResultMethods.Json(true, "در حال ورود به پنل...", "", modelVm.returnUrl);
                }
            }
            catch (Exception ex)
            {

                return CustomJsonResultMethods.Json(false, ex.Message);
            }

            return CustomJsonResultMethods.Json(false, "پر کردن همه فیلدها اجباری است", "", modelVm.returnUrl);
        }

        [Route("Auth/SignOut")]
        [HttpPost]
        public async Task<IActionResult> SignOut(string returnUrl = null)
        {
            await _sharedRepository._signInManager().SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                //return RedirectToAction("SignIn");
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
