using System;
using System.Collections.Generic;
using System.Text;
using TT.Data;
using TT.Framework;
using TT.Library.Entity;

namespace TT.Library.Repository
{
    public class SellProductRepository : Repository<SellProduct , int, TTDbContext> , ISellProductRepository
    {
        public SellProductRepository( TTDbContext dbContext ) : base(dbContext)
        {

        }
    }
}
