using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
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
using WebUI.Models.ViewModels;
using Microsoft.Extensions.Logging;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    [Route("Layout")]
    public class LayoutController : BaseController
    {
        private readonly ILogger<LayoutController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public LayoutController(
            ILogger<LayoutController> logger,
            IUnitOfWork unitOfWork,
            ISharedRepository sharedRepository) : base(sharedRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        [Route("_Partials")]
        public async Task<IActionResult> _Partials(LayoutVm modelVm)
        {
            var user = await _sharedRepository._userManager().GetUserAsync(User);
            modelVm.AppUser = user;

            switch (modelVm.Partial)
            {
                case LayoutPartialEnum.PageNavbar:
                    return PartialView("Partials/_PageNavbar",modelVm);
                case LayoutPartialEnum.PageNavbarProduct:
                    return PartialView("Partials/_PageNavbarProduct", modelVm);
                case LayoutPartialEnum.PageNavbar_Admin:
                    return PartialView("Partials/_PageNavbar_Admin",modelVm);
                case LayoutPartialEnum.PageNavbar_User:
                    return PartialView("Partials/_PageNavbar_User",modelVm);

                case LayoutPartialEnum.PageFooter:
                    return PartialView("Partials/_PageFooter",modelVm);
                case LayoutPartialEnum.PageFooter_Admin:
                    return PartialView("Partials/_PageFooter_Admin",modelVm);
                case LayoutPartialEnum.PageFooter_User:
                    return PartialView("Partials/_PageFooter_User",modelVm);

                case LayoutPartialEnum.PageSidebar:
                    return PartialView("Partials/_PageSidebar",modelVm);
                case LayoutPartialEnum.PageSidebar_Admin:
                    return PartialView("Partials/_PageSidebar_Admin",modelVm);
                case LayoutPartialEnum.PageSidebar_User:
                    return PartialView("Partials/_PageSidebar_User",modelVm);
                default:
                    break;
            }
            return PartialView("Partials/_ETC",modelVm);
        }
    }
}
