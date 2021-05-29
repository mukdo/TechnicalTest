using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechicalTest.Web.Areas.Admin.Models.Products;
using TechicalTest.Web.Areas.Admin.Models.SellProducts;

namespace TechicalTest.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ProductModel>();
            builder.RegisterType<SellProductModel>();

            base.Load(builder);
        }
    }
}

