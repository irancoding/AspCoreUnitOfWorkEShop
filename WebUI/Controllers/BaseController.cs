using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using WebUI.Core;
using WebUI.Core.Enum;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Application.Contracts;
using Domain.Enum;

namespace WebUI.Controllers
{
    public class BaseController :Controller
    {
        public ISharedRepository _sharedRepository { get; set; }
        public string userId;
        public BaseController(ISharedRepository sharedRepository)
        {            
            _sharedRepository = sharedRepository;
            //userId = sharedRepository._httpContextAccessor().HttpContext.Session.GetInt32("userId") == null ? 0 : sharedRepository._httpContextAccessor().HttpContext.Session.GetInt32("userId").Value;            
            userId= _sharedRepository._httpContextAccessor().HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
