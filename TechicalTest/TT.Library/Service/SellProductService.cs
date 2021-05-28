using System;
using System.Collections.Generic;
using System.Text;
using TT.Library.Entity;

namespace TT.Library.Service
{
    public class SellProductService : ISellProductService
    {
        public void CreateSellProduct(SellProduct product)
        {
            throw new NotImplementedException();
        }

        public SellProduct DeleteSellProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EditSellProduct(SellProduct product)
        {
            throw new NotImplementedException();
        }

        public SellProduct GetSellProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public (IList<Product> sellProducts, int total, int totalDisplay) GetSellProducts(int pageindex, int Pagesize, string searchText, string sortText)
        {
            throw new NotImplementedException();
        }
    }
}
