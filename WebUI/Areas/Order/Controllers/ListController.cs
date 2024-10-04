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

namespace WebUI.Areas.Order.Controllers
{
    [Area("Order")]
    [Route("Order/List")]
    public class ListController : BaseController
    {
        private readonly ILogger<ListController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ListController(
            ILogger<ListController> logger,
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
        [Route("CreateOrder")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<CustomJsonResult> CreateOrder(OrderVm modelVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.CreateTransaction();

                    modelVm.CreatorUserId = userId;
                    var dto = _unitOfWork._OrderRepository.MapVmToDto(modelVm);
                    await _unitOfWork._OrderRepository.CreateAsync(dto);

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
        [Route("_Read_Order")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<IActionResult> _Read_Order(OrderReadVm modelVm)
        {
            switch (modelVm.Partial)
            {
                case OrderPartialEnum.Read_Select:
                    var listItemOrder =await _unitOfWork._OrderRepository.GetAllAsync();
                    modelVm.ListOrderVm =_unitOfWork._OrderRepository.ListVM(listItemOrder).ToList();
                    return PartialView("Partials/List/Read/_Read_Select", modelVm);
            }
            return PartialView("Partials/List/Read/_ReadGrid", modelVm);
        }

        [Route("ReadGrid")]
        [Authorize(Roles = GlobalRoles.User + "," + GlobalRoles.DocumentOwnerRead)]
        public async Task<ActionResult> ReadGrid([DataSourceRequest] DataSourceRequest request, OrderReadVm modelVm)
        {
            var list = await _unitOfWork._OrderRepository.GetAllAsync();
            return Json(_unitOfWork._OrderRepository.ListVM(list).OrderByDescending(s => s.RegisterDate).ToDataSourceResult(request));
        }

        [HttpGet]
        [Route("_Update")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<ActionResult> _Update(OrderVm modelVm)
        {
            var modelItem = await _unitOfWork._OrderRepository.GetByIdAsync(modelVm.Id);
            modelVm = _unitOfWork._OrderRepository.MapEntityToVm(modelItem);
            ModelState.Clear();
            return PartialView("Partials/List/Update/_Update", modelVm);
        }

        [HttpPost]
        [Route("Update")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<CustomJsonResult> Update(OrderVm modelVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var modelItem = await _unitOfWork._OrderRepository.GetByIdAsync(modelVm.Id);

                    _unitOfWork.CreateTransaction();
                    _unitOfWork._OrderRepository.Update(modelItem);
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
        public ActionResult _Delete(OrderVm modelVm)
        {
            return PartialView("Partials/List/Delete/_Delete", modelVm);
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public CustomJsonResult Delete(OrderVm modelVm)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                if (string.IsNullOrEmpty(modelVm.Payload))
                {
                    var model = _unitOfWork._OrderRepository.GetByIdAsync(modelVm.Id);
                    _unitOfWork._OrderRepository.DeleteOrder(_unitOfWork._OrderRepository.MapVmToDto(modelVm));
                }
                else
                {
                    foreach (var item in modelVm.Payload.Split(","))
                    {
                        modelVm.Id = Guid.Parse(item);
                        _unitOfWork._OrderRepository.DeleteOrder(_unitOfWork._OrderRepository.MapVmToDto(modelVm));
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
        public async Task<ActionResult> _Partials(OrderReadVm modelVm)
        {
            var lsitItems = await _unitOfWork._OrderRepository.GetAllAsync(s => s.Id == modelVm.Id);
            modelVm.OrderVm = _unitOfWork._OrderRepository.ListVM(lsitItems).FirstOrDefault();

            switch (modelVm.Partial)
            {
                case OrderPartialEnum.ETC_PageTab:
                    return PartialView("Partials/List/ETC/_ETC_PageTab", modelVm);
            }

            return PartialView("Partials/List/ETC/_ETC", modelVm);
        }
    }
}
