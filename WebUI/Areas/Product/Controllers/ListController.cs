using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Authorization;
using Application.Contracts;
using Infrastructure.Result;
using Domain.Models.Constants;
using Infrastructure.Repositories;
using WebUI.Controllers;
using Microsoft.Extensions.Logging;
using Application.ViewModels;
using Domain.Enum;
using AutoMapper;

namespace WebUI.Areas.Product.Controllers
{
    [Area("Product")]
    [Route("Product/List")]
    public class ListController : BaseController
    {
        private readonly ILogger<ListController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ListController(
            ILogger<ListController> logger,
            IUnitOfWork unitOfWork,
            ISharedRepository sharedRepository, IMapper mapper) : base(sharedRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("_Create")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public ActionResult _Create()
        {
            ModelState.Clear();
            return PartialView("Partials/List/Create/_Create");
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<CustomJsonResult> Create(ProductVm modelVm)
        {
            try
            {               
                if (ModelState.IsValid)
                {
                    _unitOfWork.CreateTransaction();

                    modelVm.CreatorUserId = userId;
                    var dto = _unitOfWork._ProductRepository.MapVmToDto(modelVm);
                    await _unitOfWork._ProductRepository.CreateAsync(dto);

                    _unitOfWork.Save();
                    _unitOfWork.Commit();

                    return CustomJsonResultMethods.Json(true, "Operations was done successfully!");
                }

                return CustomJsonResultMethods.Json(false, "Please fill important fields!");
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                return CustomJsonResultMethods.Json(false, ex.Message);
            }            
        }

        [HttpGet]
        [Route("_Read_Product")]
        public async Task<IActionResult> _Read_Product(ProductReadVm modelVm)
        {
            var listItems=await _unitOfWork._ProductRepository.GetAllAsync();
            return PartialView("Partials/List/Read/_ReadGrid", modelVm);
        }

        [Route("ReadGrid")]
        [Authorize(Roles = GlobalRoles.User + "," + GlobalRoles.DocumentOwnerRead)]
        public async Task<ActionResult> ReadGrid([DataSourceRequest] DataSourceRequest request, ProductReadVm modelVm)
        {
            var list=await _unitOfWork._ProductRepository.GetAllAsync();
            return Json(_unitOfWork._ProductRepository.ListVM(list).OrderByDescending(s => s.RegisterDate).ToDataSourceResult(request));
        }

        [HttpGet]
        [Route("_Update")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<ActionResult> _Update(ProductVm modelVm)
        {
            var modelItem =await _unitOfWork._ProductRepository.GetByIdAsync(modelVm.Id);
            modelVm = _unitOfWork._ProductRepository.MapEntityToVm(modelItem);
            ModelState.Clear();
            return PartialView("Partials/List/Update/_Update", modelVm);
        }

        [HttpPost]
        [Route("Update")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<CustomJsonResult> Update(ProductVm modelVm)
        {
            try
            {               
                if (ModelState.IsValid)
                {
                    var modelItem =await _unitOfWork._ProductRepository.GetByIdAsync(modelVm.Id);
                    var productDto = _mapper.Map<ProductDto>(modelVm);
                    _unitOfWork.CreateTransaction();
                    _unitOfWork._ProductRepository.Update(modelVm.Id, productDto);
                    _unitOfWork.Save();
                    _unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                return CustomJsonResultMethods.Json(false, ex.Message);
            }

            return CustomJsonResultMethods.Json(true, "اطلاعات با موفقیت در سیستم ثبت شد");
        }

        [HttpGet]
        [Route("_Delete")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public ActionResult _Delete(ProductVm modelVm)
        {
            return PartialView("Partials/List/Delete/_Delete", modelVm);
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public CustomJsonResult Delete(ProductVm modelVm)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                if (string.IsNullOrEmpty(modelVm.Payload))
                {
                    var model = _unitOfWork._ProductRepository.GetByIdAsync(modelVm.Id);
                    _unitOfWork._ProductRepository.DeleteProduct(_unitOfWork._ProductRepository.MapVmToDto(modelVm));
                }
                else
                {
                    foreach (var item in modelVm.Payload.Split(","))
                    {
                        modelVm.Id = Guid.Parse(item);
                        _unitOfWork._ProductRepository.DeleteProduct(_unitOfWork._ProductRepository.MapVmToDto(modelVm));
                    }
                }

                _unitOfWork.Save();
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                return CustomJsonResultMethods.Json(false, ex.Message);
            }

            return CustomJsonResultMethods.Json(true, "اطلاعات با موفقیت در سیستم ثبت شد");
        }

        [HttpGet]
        [Route("_Partials_Product")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<ActionResult> _Partials_Product(ProductReadVm modelVm)
        {
            var lsitItems=await _unitOfWork._ProductRepository.GetAllAsync(s => s.Id == modelVm.Id);
            modelVm.ProductVm= _unitOfWork._ProductRepository.ListVM(lsitItems).FirstOrDefault();

            switch (modelVm.Partial)
            {
                case ProductPartialEnum.ETC_PageTab:
                    return PartialView("Partials/List/ETC/_ETC_PageTab", modelVm);
            }

            return PartialView("Partials/List/ETC/_ETC", modelVm);
        }
    }
}
