using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models.ViewModels
{
    public class NavbarVm
    {
        public NavbarVm()
        {
            ListUserOrganization = new List<string>();
        }
        public AppUser AppUser { get; set; }
        public string Role { get; set; }
        public List<string> ListUserOrganization { get; set; }
    }
}
