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

namespace WebUI.Areas.OrderProduct.Controllers
{
    [Area("Order")]
    [Route("Order/OrderProduct")]
    public class OrderProductController : BaseController
    {
        private readonly ILogger<OrderProductController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public OrderProductController(
            ILogger<OrderProductController> logger,
            IUnitOfWork unitOfWork,
            ISharedRepository sharedRepository) : base(sharedRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("CreateOrderProduct")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<CustomJsonResult> CreateOrderProduct(OrderProductVm modelVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.CreateTransaction();

                    modelVm.CreatorUserId = userId;
                    var dto = _unitOfWork._OrderProductRepository.MapVmToDto(modelVm);
                    await _unitOfWork._OrderProductRepository.CreateAsync(dto);

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
        [Route("_Read_OrderProduct")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<IActionResult> _Read_OrderProduct(OrderProductReadVm modelVm)
        {
            switch (modelVm.Partial)
            {
                case OrderProductPartialEnum.Read_Select:
                    var listItemOrderProduct =await _unitOfWork._OrderProductRepository.GetAllAsync();
                    modelVm.ListOrderProductVm =_unitOfWork._OrderProductRepository.ListVM(listItemOrderProduct).ToList();
                    return PartialView("Partials/List/Read/_Read_Select", modelVm);
            }
            return PartialView("Partials/List/Read/_ReadGrid", modelVm);
        }

        [Route("ReadGrid")]
        [Authorize(Roles = GlobalRoles.User + "," + GlobalRoles.DocumentOwnerRead)]
        public async Task<ActionResult> ReadGrid([DataSourceRequest] DataSourceRequest request, OrderProductReadVm modelVm)
        {
            var list = await _unitOfWork._OrderProductRepository.GetAllAsync();
            return Json(_unitOfWork._OrderProductRepository.ListVM(list).OrderByDescending(s => s.RegisterDate).ToDataSourceResult(request));
        }

        [HttpGet]
        [Route("_Update")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<ActionResult> _Update(OrderProductVm modelVm)
        {
            var modelItem = await _unitOfWork._OrderProductRepository.GetByIdAsync(modelVm.Id);
            modelVm = _unitOfWork._OrderProductRepository.MapEntityToVm(modelItem);
            ModelState.Clear();
            return PartialView("Partials/List/Update/_Update", modelVm);
        }

        [HttpPost]
        [Route("Update")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<CustomJsonResult> Update(OrderProductVm modelVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var modelItem = await _unitOfWork._OrderProductRepository.GetByIdAsync(modelVm.Id);

                    _unitOfWork.CreateTransaction();
                    _unitOfWork._OrderProductRepository.Update(modelItem);
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
        public ActionResult _Delete(OrderProductVm modelVm)
        {
            return PartialView("Partials/List/Delete/_Delete", modelVm);
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public CustomJsonResult Delete(OrderProductVm modelVm)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                if (string.IsNullOrEmpty(modelVm.Payload))
                {
                    var model = _unitOfWork._OrderProductRepository.GetByIdAsync(modelVm.Id);
                    _unitOfWork._OrderProductRepository.DeleteOrderProduct(_unitOfWork._OrderProductRepository.MapVmToDto(modelVm));
                }
                else
                {
                    foreach (var item in modelVm.Payload.Split(","))
                    {
                        modelVm.Id = Guid.Parse(item);
                        _unitOfWork._OrderProductRepository.DeleteOrderProduct(_unitOfWork._OrderProductRepository.MapVmToDto(modelVm));
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
        [Route("_Partials")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<ActionResult> _Partials(OrderProductReadVm modelVm)
        {
            var lsitItems = await _unitOfWork._OrderProductRepository.GetAllAsync(s => s.Id == modelVm.Id);
            modelVm.OrderProductVm = _unitOfWork._OrderProductRepository.ListVM(lsitItems).FirstOrDefault();

            switch (modelVm.Partial)
            {
                case OrderProductPartialEnum.ETC_PageTab:
                    return PartialView("Partials/List/ETC/_ETC_PageTab", modelVm);
            }

            return PartialView("Partials/List/ETC/_ETC", modelVm);
        }
    }
}
