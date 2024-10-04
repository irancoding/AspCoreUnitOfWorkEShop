using Domain.Enum;
using WebUI.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models.Auth
{
    public class SignInVm
    {
        public int Id { get; set; }

        [Display(Name = "کد ملی")]
        //[MinLength(10, ErrorMessage = "کد ملی 10 رقمی می باشد")]
        //[MaxLength(10, ErrorMessage = "کد ملی 10 رقمی می باشد")]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [Display(Name = "کد ملی")]
        public string MobileNumber { get; set; }

        [EmailAddress(ErrorMessage = "فیلد {0} ضروری است")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        public string returnUrl { get; set; }

        public EnumRoleMain Role { get; set; }

        [Display(Name = "بخش")]
        public int LabSectionId { get; set; }
    }
}
