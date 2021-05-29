using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TT.Library.Service;

namespace TechicalTest.Web.Areas.Admin.Models.Products
{
    public class ProductBaseModel : AdminBaseModel , IDisposable
    {
        protected IProductService _poductService;
        public ProductBaseModel()
        {
            _poductService = Startup.AutofacContainer.Resolve<IProductService>();
        }

        public ProductBaseModel( IProductService productService)
        {
            _poductService = productService;
        }
        public void Dispose()
        {
            _poductService.Dispose();
        }
    }
}
