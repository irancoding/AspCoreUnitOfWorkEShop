
using WebUI.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models.Auth
{
    public class SignVm
    {
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "شماره موبایل")]
        public string? MobileNumber { get; set; }

        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "رمز عبورها مشابه نیستند !")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "کد پیامک")]
        public string SMSCode { get; set; }
        public string returnUrl { get; set; }


    }
}
