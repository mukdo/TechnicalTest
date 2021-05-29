using Autofac;
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

    }
}
