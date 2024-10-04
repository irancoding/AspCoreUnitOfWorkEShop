
using WebUI.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models.Auth
{
    public class SignUpVm
    {
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [Display(Name = "شماره موبایل")]
        public string? MobileNumber { get; set; }

        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "رمز عبورها مشابه نیستند !")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [Display(Name = "کد پیامک")]
        public string SMSCode { get; set; }
        public string returnUrl { get; set; }

    }
}
