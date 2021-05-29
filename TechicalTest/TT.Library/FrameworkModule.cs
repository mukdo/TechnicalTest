using Autofac;
using System;
using TT.Library.Repository;
using TT.Library.Service;
using TT.MemberShip.Contexts;
using TT.MemberShip.Data;

namespace TT.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TTDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<TTUnitOfWork>().As<ITTUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SellProductRepository>().As<ISellProductRepository>()
               .InstancePerLifetimeScope();


            builder.RegisterType<ProductService>().As<IProductService>()
             .InstancePerLifetimeScope();

            builder.RegisterType<SellProductService>().As<ISellProductService>()
               .InstancePerLifetimeScope();
            base.Load(builder);

            builder.RegisterType<AccountSeed>()
           .InstancePerLifetimeScope();
        }
    }
}
