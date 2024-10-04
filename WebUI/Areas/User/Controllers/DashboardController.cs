using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using WebUI.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Contracts;
using Infrastructure.Result;
using Infrastructure.Services;
using Domain.Models.Constants;
using Infrastructure.Repositories;
using Infrastructure.Database;
using Domain.Enum;
using Application.ViewModels;
using WebUI.Controllers;
using Microsoft.Extensions.Logging;

namespace WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Dashboard")]
    [Authorize(Roles = GlobalRoles.Admin + "," +
                       GlobalRoles.User + "," +
                       GlobalRoles.Document + "," +
                       GlobalRoles.DocumentCreate + "," +
                       GlobalRoles.DocumentRead + "," +
                       GlobalRoles.DocumentUpdate + "," +
                       GlobalRoles.DocumentRead)]
    public class DashboardController : BaseController
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(
            ILogger<DashboardController> logger,
            IUnitOfWork unitOfWork,
            ISharedRepository sharedRepository) : base(sharedRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }

            return View("User");
        }

    }
}
