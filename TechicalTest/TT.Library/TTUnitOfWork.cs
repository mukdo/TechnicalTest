using TT.Data;
using System;
using System.Collections.Generic;
using System.Text;
using TT.Library.Repository;

namespace TT.Framework
{
    public class TTUnitOfWork : UnitOfWork, ITTUnitOfWork
    {
        public IProductRepository ProductRepository { get; set; }
        public ISellProductRepository SellProductRepository { get; set; }

        public TTUnitOfWork( TTDbContext frameworkContext  , IProductRepository productRepository , 
                                                             ISellProductRepository sellProductRepository)
            :base(frameworkContext)
        {
            ProductRepository = productRepository;
            SellProductRepository = sellProductRepository;
         
        }

       }
}
