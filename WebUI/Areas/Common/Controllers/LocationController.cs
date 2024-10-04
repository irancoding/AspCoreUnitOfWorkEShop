//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Kendo.Mvc.UI;
//using Kendo.Mvc.Extensions;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics;
//using System.Data;
//using Microsoft.Data.SqlClient;
//using Microsoft.IdentityModel.Protocols;
//using System.Security.Claims;
//using Domain.Entities;
//using Application.Contracts;
//using Infrastructure.Result;
//using Infrastructure.Services;
//using Domain.Models.Constants;
//using Infrastructure.Repositories;
//using Infrastructure.Database;
//using Domain.Enum;
//using Application.ViewModels;
//using WebUI.Controllers;
//using Microsoft.Extensions.Logging;

//namespace WebUI.Areas.Common.Controllers
//{
//    [Area("Common")]
//    [Route("Common/Location")]
//    [AllowAnonymous]
//    public class LocationController : BaseController
//    {
//        private readonly ILogger<LocationController> _logger;
//        private readonly IUnitOfWork _unitOfWork;

//        public LocationController(
//            ILogger<LocationController> logger,
//            IUnitOfWork unitOfWork,
//            ISharedRepository sharedRepository, ILocationRepository locationRepository) : base(sharedRepository)
//        {
//            _unitOfWork = unitOfWork;
//            _logger = logger;
//        }

//        [HttpGet]
//        public ActionResult Index()
//        {
//            return View();
//        }

//        [HttpGet]
//        [Route("_Create")]
//        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.DocumentOwnerCreate)]
//        public async Task<ActionResult> _Create(LocationVm modelVm)
//        {
//            ModelState.Clear();
//            modelVm.Location = await _unitOfWork._LocationRepository.GetByIdAsync(modelVm.ParentId.Value);
//            return PartialView("Partials/Location/_Create", modelVm);
//        }

//        [HttpPost]
//        [Route("Create")]
//        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.DocumentOwnerUpdate)]
//        public async Task<CustomJsonResult> Create(LocationVm modelVm)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var modelItemLocation = new Domain.Entities.Location()
//                    {
//                        Name = modelVm.Name,
//                        Description = modelVm.Description,
//                        Status = modelVm.Status,
//                        Type=LocationTypeEnum.Country,
//                        IsEnable = true,
//                        ParentId= modelVm.ParentId
//                    };

//                    var modelItemParent = await _unitOfWork._LocationRepository.GetByIdAsync(modelVm.ParentId.Value);

//                    if (modelItemParent!=null)
//                    {
//                        switch (modelItemParent.Type)
//                        {
//                            case LocationTypeEnum.Country:
//                                modelItemLocation.Type = LocationTypeEnum.Province;
//                                break;
//                            case LocationTypeEnum.Province:
//                                modelItemLocation.Type = LocationTypeEnum.City;
//                                break;
//                            case LocationTypeEnum.City:
//                                modelItemLocation.Type = LocationTypeEnum.Region;
//                                break;
//                        }
//                    }

//                    _unitOfWork.CreateTransaction();
//                    await _unitOfWork._LocationRepository.AddAsync(modelItemLocation);
//                    _unitOfWork.Save();
//                    _unitOfWork.Commit();
//                }
//                else
//                {
//                    return CustomJsonResultMethods.Json(false, "اطلاعات ضروری می بایست وارد شوند");
//                }
//            }
//            catch (Exception ex)
//            {
//                _unitOfWork.Rollback();

//                return CustomJsonResultMethods.Json(false, ex.Message);
//            }
//            return CustomJsonResultMethods.Json(true, "اطلاعات با موفقیت در سیستم ثبت شد");
//        }


//        [HttpGet]
//        [Route("_Read")]
//        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.DocumentOwnerRead)]
//        public IActionResult _Read(LocationReadVm modelVm)
//        {

//            return PartialView("Partials/Location/Read/_Read", modelVm);
//        }

//        [Route("ReadGrid")]
//        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.DocumentOwnerRead)]
//        public async Task<ActionResult> ReadGrid([DataSourceRequest] DataSourceRequest request, LocationVm modelVm)
//        {
//            var listItems =await _unitOfWork._LocationRepository.GetAllAsync();
//            return Json(_unitOfWork._LocationRepository.ListModel(listItems).OrderByDescending(s => s.Id).ToDataSourceResult(request));
//        }

//        [HttpGet]
//        [Route("_Update")]
//        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.DocumentOwnerUpdate)]
//        public ActionResult _Update(LocationVm modelVm)
//        {
//            Location modelItem = _unitOfWork._LocationRepository.GetById(modelVm.Id);

//            modelVm.Name = modelItem.Name;
//            modelVm.Description = modelItem.Description;
//            modelVm.Code = modelItem.Code;
//            modelVm.NO = modelItem.NO;
//            modelVm.Status = modelItem.Status;

//            ModelState.Clear();
//            return PartialView("Partials/Location/_Update", modelVm);
//        }


//        [HttpPost]
//        [Route("Update")]
//        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.DocumentOwnerUpdate)]
//        public CustomJsonResult Update(LocationVm modelVm)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {                    
//                    var modelItemLocation = _repository.GetById(modelVm.Id);

//                    modelItemLocation.Name = modelVm.Name;
//                    modelItemLocation.Description = modelVm.Description;
//                    modelItemLocation.Status = modelVm.Status;
//                    modelItemLocation.IsEnable = true;

//                    unitOfWork.CreateTransaction();

//                    _repository.Update(modelItemLocation);

//                    unitOfWork.Save();
//                    unitOfWork.Commit();
//                }
//                else
//                {
//                    return CustomJsonResultMethods.Json(false, "اطلاعات ضروری می بایست وارد شوند");
//                }
//            }
//            catch (Exception ex)
//            {
//                unitOfWork.Rollback();

//                return CustomJsonResultMethods.Json(false, ex.Message);
//            }
//            return CustomJsonResultMethods.Json(true, "اطلاعات با موفقیت در سیستم ثبت شد");
//        }


//        [HttpGet]
//        [Route("_Delete")]
//        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.DocumentOwnerDelete)]
//        public ActionResult _Delete(LocationVm modelVm)
//        {
//            Location model = _repository.GetById(modelVm.Id);
//            return PartialView("Partials/Location/_Delete", model);
//        }

//        [HttpPost]
//        [Route("Delete")]
//        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.DocumentOwnerDelete)]
//        public CustomJsonResult Delete(LocationVm modelVm)
//        {
//            try
//            {
//                Location model = _repository.GetById(modelVm.Id);
//                //Utils.FileUtils.DeleteFile(model.FileLogo);
//                _repository.Delete(model);
//                unitOfWork.Save();

//                unitOfWork.Commit();
//            }
//            catch (Exception ex)
//            {
//                return CustomJsonResultMethods.Json(false, ex.Message);
//            }


//            return CustomJsonResultMethods.Json(true, "اطلاعات با موفقیت در سیستم ثبت شد");
//        }



//        public JsonResult All([DataSourceRequest] DataSourceRequest request)
//        {
//            var result = GetDirectory().ToTreeDataSourceResult(request,
//                e => e.Id,
//                e => e.ParentId,
//                e => e
//            );

//            return Json(result);
//        }
//        private IEnumerable<LocationVm> GetDirectory()
//        {
//            return _LocationRepository.ListModel(_LocationRepository.GetAll());
//        }

//        //-------------------------------------------------------
//        [HttpGet]
//        [Route("_ReadFree")]
//        public IActionResult _ReadFree(LocationReadVm modelVm)
//        {
//            modelVm.ListLocationVm = _LocationRepository.ListModel(_repository.GetAll()).ToList();

//            return PartialView("Partials/Location/Read/_Read_OrderListCreateInHome", modelVm);
//        }
//    }
//}
