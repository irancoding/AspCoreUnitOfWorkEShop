using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels;
using Domain.Entities;
using Domain;
using Infrastructure.Repositories;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Result;
using Microsoft.AspNetCore.Identity;
using Infrastructure;
using Domain.Enum;
using Domain.Models.Constants;
using System.Security.Claims;
using Infrastructure.Utils;
using Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Application.Contracts;
using WebUI.Controllers;
using Microsoft.Extensions.Logging;

namespace WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/List")]
    [Authorize(Roles = GlobalRoles.Admin + "," +
                       GlobalRoles.User + "," +
                       GlobalRoles.UserCreate + "," +
                       GlobalRoles.UserRead + "," +
                       GlobalRoles.UserUpdate + "," +
                       GlobalRoles.UserRead)]
    public class ListController : BaseController
    {
        private IUserRepository _UserRepository;
        private IPasswordHasher<AppUser> passwordHasher;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILogger<ListController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ListController(
            ILogger<ListController> logger,
            IUnitOfWork unitOfWork,
            ISharedRepository sharedRepository, IUserRepository userRepository, IPasswordHasher<AppUser> passwordHasher, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor) : base(sharedRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _UserRepository = userRepository;
            this.passwordHasher = passwordHasher;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ActionResult Index(UserReadVm modelVm)
        {
            return View();
        }

        [HttpGet]
        [Route("_Create")]
        public async Task<ActionResult> _Create(UserVm modelVm)
        {
            var modelListItemUser = _UserRepository.GetUserList().ToList();
            var modelItem = modelListItemUser.FirstOrDefault(s => s.UserCreatorId == userId && s.IsEnable == false);
            _unitOfWork.CreateTransaction();
            _UserRepository.DeleteUser(modelItem);
            _unitOfWork.Save();
            _unitOfWork.Commit();

            
            var lastModelItem = modelListItemUser.OrderByDescending(s => s.DateRegister).FirstOrDefault();
            var model = new AppUser()
            {
                UserCreatorId = userId,
                IsEnable = false,
                Code = lastModelItem == null ? "1" : NumberUtils.GetFirstLackNumberStr(modelListItemUser.Select(s => s.Code).ToList()),
                DateRegister = DateTime.Now,
                Gender = true,
                UserType = EnumRoleMain.User
            };

            _unitOfWork.CreateTransaction();
            await _unitOfWork._UserRepository.CreateAsync(model);
            _unitOfWork.Save();
            _unitOfWork.Commit();

            modelVm.Id = model.Id;
            modelVm.Code = model.Code;
            modelVm.IsEnable = model.IsEnable;

            ModelState.Clear();

            return PartialView("Partials/User/Create/_Create", modelVm);
        }

        [HttpGet]
        [Route("_Read")]
        public IActionResult _Read(UserReadVm modelVm)
        {
            switch (modelVm.Partial)
            {
                case UserPartialEnum.Read_Select:
                    modelVm.ListUserVm = _UserRepository.ListVM(_UserRepository.GetUserList()).ToList();
                    return PartialView("Partials/User/Read/_Read_Select", modelVm);
            }
            return PartialView("Partials/User/Read/_Read", modelVm);
        }

        [Route("ReadGrid")]
        public ActionResult ReadGrid([DataSourceRequest] DataSourceRequest request, UserReadVm modelVm)
        {
            return Json(_UserRepository.ListVM(_UserRepository.GetUserList().Where(s => s.IsEnable == true)).OrderByDescending(s => s.DateRegister).ToDataSourceResult(request));
        }

        [HttpGet]
        [Route("_Update")]
        public ActionResult _Update(string UserId)
        {
            //پیدا کردن اولین سطر ایجاد شده قطعی نشده
            var modelItem = _UserRepository.GetUserList().Where(s => s.Id == UserId).FirstOrDefault();
            var pop = DateTimeUtils.CompleteDateToApartDate(modelItem.DateBirth);
            var lastModelItem = _UserRepository.GetUserList().LastOrDefault();
            var modelVm = new UserVm()
            {
                Id = modelItem.Id,
                FileAvatarStr = modelItem.FileAvatar,
                FileSignatureStr = modelItem.FileSignature,
                FullName = modelItem.FullName,
                UserName = modelItem.UserName,
                Year = DateTimeUtils.CompleteDateToApartDate(modelItem.DateBirth)[0],
                Month = DateTimeUtils.CompleteDateToApartDate(modelItem.DateBirth)[1],
                Day = DateTimeUtils.CompleteDateToApartDate(modelItem.DateBirth)[2],
                Email = modelItem.Email,
                Gender = modelItem.Gender,
                IsEnable = modelItem.IsEnable,
                MobileNumber = modelItem.MobileNumber,
                PhoneNumber = modelItem.PhoneNumber,
                Symbol = modelItem.Symbol,
                UserType = modelItem.UserType,
                Status = modelItem.Status,
                IsEdit = true,
                NationalCode = modelItem.NationalCode,
                Code = string.IsNullOrEmpty(modelItem.Code) ? (_UserRepository.GetUserList().Count() + 1).ToString() : modelItem.Code
            };

            ModelState.Clear();
            return PartialView("Partials/User/Update/_Update", modelVm);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<CustomJsonResult> Update(UserVm modelVm)
        {
            try
            {
                AppUser modelItemUser = await _userManager.FindByIdAsync(modelVm.Id);
                var result = await _roleManager.CreateAsync(new AppRole { Name = EnumRoleMain.User.ToString() });
                result = await _roleManager.CreateAsync(new AppRole { Name = EnumRoleMain.Admin.ToString() });

                if (ModelState.IsValid)
                {
                    _unitOfWork.CreateTransaction();

                    if (modelVm.FileAvatar != null)
                    {
                        modelItemUser.FileAvatar = FileUtils.UploadFile(modelVm.FileAvatar);
                    }
                    else
                    {
                        if (modelVm.avatar_remove == 1)
                        {
                            FileUtils.DeleteFile(modelItemUser.FileAvatar);
                            modelItemUser.FileAvatar = null;
                        }
                    }

                    if (modelVm.FileSignature != null)
                    {
                        modelItemUser.FileSignature = FileUtils.UploadFile(modelVm.FileSignature);
                    }
                    else
                    {
                        if (modelVm.signature_remove == 1)
                        {
                            FileUtils.DeleteFile(modelItemUser.FileSignature);
                            modelItemUser.FileSignature = null;
                        }
                    }

                    modelItemUser.FullName = modelVm.FullName;
                    modelItemUser.UserName = modelVm.UserName;
                    modelItemUser.Status = modelVm.Status != UserStatusEnum.Active ? UserStatusEnum.InActive : modelVm.Status;
                    modelItemUser.Gender = modelVm.Gender;
                    modelItemUser.Email = modelVm.Email;
                    modelItemUser.UserType = modelVm.UserType;
                    modelItemUser.DateBirth = DateTimeUtils.ApartDateToCompleteDate(modelVm.Year, modelVm.Month, modelVm.Day);
                    modelItemUser.PhoneNumber = modelVm.PhoneNumber;

                    if (!modelVm.IsEdit)
                    {
                        modelItemUser.PasswordHash = passwordHasher.HashPassword(modelItemUser, modelVm.Password);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(modelVm.Password2))
                        {
                            modelItemUser.PasswordHash = passwordHasher.HashPassword(modelItemUser, modelVm.Password2);
                        }
                    }

                    modelItemUser.Symbol = modelVm.Symbol;
                    modelItemUser.MobileNumber = modelVm.MobileNumber;
                    modelItemUser.IsEnable = true;
                    if (modelItemUser.DateRegister == DateTime.MinValue)
                    {
                        modelItemUser.DateRegister = DateTime.Now;
                    }

                    _UserRepository.Update(modelItemUser);

                    //مراحل
                    //01-حذف همه نقش های قبلی کاربر
                    //02-حذف مجوزهای غیرگروهی کاربر از جدول مجوزهای کاربر
                    //03-افزودن مجوزها انتخاب شده به مجوزهای کاربر 
                    //04-افزودن مجوزهای کاربر به جدول نقش های کاربر

                    var user = await _userManager.FindByIdAsync(modelVm.Id);

                    //حذف همه نقش های قبلی
                    var roles = await _userManager.GetRolesAsync(user);

                    await _userManager.RemoveFromRolesAsync(user, roles.ToArray());

                    _unitOfWork.Save();
                    _unitOfWork.Commit();


                    return CustomJsonResultMethods.Json(true, "اطلاعات با موفقیت در سیستم ثبت شد");
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                return CustomJsonResultMethods.Json(false, ex.Message);
            }

            return CustomJsonResultMethods.Json(false, "اطلاعات به درستی وارد نشده اند");
        }

        [HttpGet]
        [Route("_Delete")]
        public ActionResult _Delete(string UserId)
        {
            return PartialView("Partials/User/Delete/_Delete");
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<CustomJsonResult> Delete(string Id)
        {
            try
            {
                var modelItem =await _UserRepository.GetUserById(Id);
                _UserRepository.DeleteUser(modelItem);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return CustomJsonResultMethods.Json(false, ex.Message);
            }

            return CustomJsonResultMethods.Json(true, "اطلاعات با موفقیت در سیستم ثبت شد");
        }
    }
}
