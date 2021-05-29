using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechicalTest.Web.Areas.Admin.Models;
using TechicalTest.Web.Areas.Admin.Models.Products;
using TechicalTest.Web.Areas.Admin.Models.SellProducts;

namespace TechicalTest.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "SuperAdmin,Administrator")]
    public class SellProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SellProductModel> _logger;

        public SellProductController(IConfiguration configuration, ILogger<SellProductModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<SellProductModel>();
            return View(model);
        }

        public IActionResult CreateSellProduct()
        {
            var model = new CreateSellProductModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSellProduct([Bind(nameof(CreateSellProductModel.ProductId),
                                                nameof(CreateSellProductModel.SellingPrice),
                                                nameof(CreateSellProductModel.Quantity),
                                                nameof(CreateSellProductModel.SellingDate))]
                                            CreateSellProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Sell Product Successful", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Product Sell Sucessfully");

                    return RedirectToAction("Index");
                }


                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Product Sell failued.", ResponseType.Failure);
                    _logger.LogError($"Sell Product Add 'Failed'. Excption is : {ex.Message}");
                }
            }

            return View(model);
        }

        public IActionResult EditSellProduct(int id)
        {
            var model = new EditSellProductModel();
            model.Load(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSellProduct([Bind(nameof(EditSellProductModel.Id),
                                                nameof(EditSellProductModel.ProductId),
                                                nameof(EditSellProductModel.SellingPrice),
                                                nameof(EditSellProductModel.SellingDate),
                                                nameof(EditSellProductModel.Quantity))]
                                            EditSellProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.EditSellProduct();
                    model.Response = new ResponseModel("Sell Product editing successful.", ResponseType.Success);

                  //  logger code
                    _logger.LogInformation("Sell Product Edit Successful");

                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Sell Product Edit Failued.", ResponseType.Failure);
                    //error logger code
                    _logger.LogError($"Sell Product Edit 'Failed'. Excption is : {ex.Message}");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSellProduct(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new SellProductModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Sell {provider} successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Sell Delete failed.", ResponseType.Failure);
                    //error logger code
                    _logger.LogError($"Sell Product Delete 'Failed'. Excption is : {ex.Message}");
                }
            }
            return RedirectToAction("index");
        }


        public IActionResult GetSellProduct()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<SellProductModel>();
            var data = model.GetSellProduct(tableModel);
            return Json(data);
        }
    }
}
}
