using TT.Data;
using System;
using System.Collections.Generic;
using System.Text;
using TT.Library.Repository;

namespace TT.Framework
{
    public interface ITTUnitOfWork:IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }
        ISellProductRepository SellProductRepository { get; set; }

    }
}
