using Autofac;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TT.Library.Service;

namespace TechicalTest.Web.Areas.Admin.Models.SellProducts
{
    public class SellProductBaseModel : AdminBaseModel
    {
        protected ISellProductService _sellPoductService;

        public SellProductBaseModel()
        {
            _sellPoductService = Startup.AutofacContainer.Resolve<ISellProductService>();
        }

        public SellProductBaseModel(ISellProductService sellProductService)
        {
            _sellPoductService = sellProductService;
        }
        public void Dispose()
        {
            _sellPoductService.Dispose();
        }

        public IList<SelectListItem> GetProductList()
        {
            IList<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _sellPoductService.GetProduct())
            {
                var ctg = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItems.Add(ctg);
            }
            return listItems;
        }
    }
}
