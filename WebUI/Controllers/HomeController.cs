using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {      
        public IActionResult Index()
        {
            return View();
        }    
    }
}
