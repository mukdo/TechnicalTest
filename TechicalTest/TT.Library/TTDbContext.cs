using Microsoft.EntityFrameworkCore;
using TT.Library.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TT.Framework
{
    public class TTDbContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public TTDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
 
            base.OnModelCreating(builder);
        }

      public DbSet<Product> Products { get; set; }
      public DbSet<SellProduct> SellProducts { get; set; }

    

       
    }
}
