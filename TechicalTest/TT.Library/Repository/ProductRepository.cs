using System;
using System.Collections.Generic;
using System.Text;
using TT.Data;
using TT.Framework;
using TT.Library.Entity;

namespace TT.Library.Repository
{
    public class ProductRepository : Repository<SellProduct, int, TTDbContext> , IProductRepository
    {
        public ProductRepository(TTDbContext dbContext) : base(dbContext)
        {

        }
    }
}
