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
using TT.Framework;

namespace TechicalTest.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Administrator")]
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductModel> _logger;

        public ProductController(IConfiguration configuration, ILogger<ProductModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<ProductModel>();
            return View(model);
        }

        public IActionResult CreateProduct()
        {
            var model = new CreateProductModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct([Bind(nameof(CreateProductModel.Name),
                                                nameof(CreateProductModel.PurchesPrice),
                                                nameof(CreateProductModel.Quantity))]
                                            CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Add a new Product Successful", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Product Create Sucessfully");

                    return RedirectToAction("Index");
                }

                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    _logger.LogError("Product Title already Exist");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Product Add failued.", ResponseType.Failure);
                    _logger.LogError($"Product Add 'Failed'. Excption is : {ex.Message}");
                }
            }

            return View(model);
        }

        public IActionResult EditProduct(int id)
        {
            var model = new EditProductModel();
            model.Load(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct([Bind(nameof(EditProductModel.Id),
                                                nameof(EditProductModel.Name),
                                                nameof(EditProductModel.PurchesPrice),
                                                nameof(EditProductModel.Quantity))]
                                            EditProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.EditProduct();
                    model.Response = new ResponseModel("Product editing successful.", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Product Edit Successful");

                    return RedirectToAction("Index");

                }

                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    _logger.LogError("Product Title already Exist");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Product Edit Failued.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Product Edit 'Failed'. Excption is : {ex.Message}");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new ProductModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Product {provider} successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Product Delete failed.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Product Delete 'Failed'. Excption is : {ex.Message}");
                }
            }
            return RedirectToAction("index");
        }


        public IActionResult GetProduct()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<ProductModel>();
            var data = model.GetProduct(tableModel);
            return Json(data);
        }
    }
}
