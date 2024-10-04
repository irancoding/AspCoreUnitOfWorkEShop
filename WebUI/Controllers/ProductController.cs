using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Application.Contracts;
using Infrastructure.Result;
using Domain.Models.Constants;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Application.ViewModels;
using Domain.Enum;
using AutoMapper;
using Infrastructure.Utils.Extensions;

namespace WebUI.Controllers
{
    [Route("Product")]
    [AllowAnonymous]
    public class ProductController : BaseController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController(
            ILogger<ProductController> logger,
            IUnitOfWork unitOfWork,
            ISharedRepository sharedRepository, IMapper mapper) : base(sharedRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Details(ProductVm modelVm)
        {
            return View("Details", modelVm);
        }
        
        [HttpGet]
        [Route("Card")]
        public ActionResult Card(ProductVm modelVm)
        {
            return View("Card", modelVm);
        }

        [HttpGet]
        [Route("_Create")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public ActionResult _Create()
        {
            ModelState.Clear();
            return PartialView("Partials/Create/_Create");
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
        [Route("_Read_Product_Site")]
        public async Task<IActionResult> _Read_Product_Site(ProductReadVm modelVm)
        {
            var listItems = await _unitOfWork._ProductRepository.GetAllAsync();

            switch (modelVm.Partial)
            {
                case ProductPartialEnum.Read_New:
                    modelVm.ListProductVm = _unitOfWork._ProductRepository.ListVM(listItems).ToList();
                    return PartialView("Partials/Read/_Read_New", modelVm);
                case ProductPartialEnum.Read_MostSale:
                    modelVm.ListProductVm = _unitOfWork._ProductRepository.ListVM(listItems).ToList();
                    return PartialView("Partials/Read/_Read_MostSale", modelVm);
                case ProductPartialEnum.Read_Recommended:
                    modelVm.ListProductVm = _unitOfWork._ProductRepository.ListVM(listItems).ToList();
                    return PartialView("Partials/Read/_Read_Recommended", modelVm);
            }

            return PartialView("Partials/Read/_Read_Recommended", modelVm);
        }

        [HttpGet]
        [Route("_Update")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<ActionResult> _Update(ProductVm modelVm)
        {
            var modelItem = await _unitOfWork._ProductRepository.GetByIdAsync(modelVm.Id);
            modelVm = _unitOfWork._ProductRepository.MapEntityToVm(modelItem);
            ModelState.Clear();
            return PartialView("Partials/Update/_Update", modelVm);
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
                    var modelItem = await _unitOfWork._ProductRepository.GetByIdAsync(modelVm.Id);
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
        [Route("_Partials_Product")]
        [Authorize(Roles = GlobalRoles.Admin + "," + GlobalRoles.User)]
        public async Task<ActionResult> _Partials_Product(ProductReadVm modelVm)
        {
            var lsitItems = await _unitOfWork._ProductRepository.GetAllAsync(s => s.Id == modelVm.Id);
            modelVm.ProductVm = _unitOfWork._ProductRepository.ListVM(lsitItems).FirstOrDefault();

            switch (modelVm.Partial)
            {
                case ProductPartialEnum.ETC_ProductDetails:
                    return PartialView("Partials/ETC/_ETC_ProductDetails", modelVm);
                case ProductPartialEnum.ETC_ProductCard:
                    modelVm.Card =await _unitOfWork._ProductRepository.ProductCard();
                    return PartialView("Partials/ETC/_ETC_ProductCard", modelVm);
                case ProductPartialEnum.ETC_PageTab:
                    return PartialView("Partials/ETC/_ETC_PageTab", modelVm);
            }

            return PartialView("Partials/ETC/_ETC", modelVm);
        }

        [HttpPost]
        [Route("SaveProductToSession")]
        public CustomJsonResult SaveProductToSession(ProductVm modelVm)
        {
            try
            {
                _unitOfWork._ProductRepository.AddToCard(modelVm.Payload);
                return CustomJsonResultMethods.Json(true, "Operations was done successfully!");
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                return CustomJsonResultMethods.Json(false, ex.Message);
            }
        }
        [HttpPost]
        [Route("DeleteProductFromSession")]
        public CustomJsonResult DeleteProductFromSession(ProductVm modelVm)
        {
            try
            {
                _unitOfWork._ProductRepository.DeleteFromCard(modelVm.Payload);
                return CustomJsonResultMethods.Json(true, "Operations was done successfully!");
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                return CustomJsonResultMethods.Json(false, ex.Message);
            }
        }
    }
}
