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
using WebUI.Core;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Contracts;
using Infrastructure.Result;
using Infrastructure.Services;
using Domain.Models.Constants;
using Infrastructure.Repositories;
using Infrastructure.Database;
using Domain.Enum;
using Application.ViewModels;
using Infrastructure.Utils.Extensions;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class CommonController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AuthController> _logger;
        private IUserRepository _UserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly ISMSService _SMSService;
        public CommonController(RoleManager<AppRole> roleManager,
                              UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager,
                              ILogger<AuthController> logger,
                              IUserRepository userRepository,
                              IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _UserRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            //_SMSService = sMSService;
        }

        [HttpPost]
        [Route("/Common/SaveToSession")]
        public CustomJsonResult SaveToSession(string key,List<int> value)
        {
            try
            {
                _httpContextAccessor.HttpContext.Session.SetObject(key, value);
                return CustomJsonResultMethods.Json(false, "پر کردن همه فیلدها اجباری است", "");
            }
            catch (Exception ex)
            {
                return CustomJsonResultMethods.Json(false, ex.Message);
            }
        }
    }
}
