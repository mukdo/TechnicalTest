using System;
using System.Collections.Generic;
using System.Text;
using TT.Data;
using TT.Framework;
using TT.Library.Entity;

namespace TT.Library.Repository
{
    public interface ISellProductRepository : IRepository<SellProduct, int, TTDbContext>
    {
    }
}
