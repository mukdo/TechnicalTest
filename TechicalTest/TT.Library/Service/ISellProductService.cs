using System;
using System.Collections.Generic;
using System.Text;
using TT.Library.Entity;

namespace TT.Library.Service
{
    public interface ISellProductService : IDisposable
    {
        (IList<SellProduct> sellProducts, int total, int totalDisplay) GetSellProducts(int pageindex,
                                                                          int Pagesize,
                                                                          string searchText,
                                                                          string sortText);
        void CreateSellProduct(SellProduct product);
        void EditSellProduct(SellProduct product);
        SellProduct GetSellProduct(int Id);
        SellProduct DeleteSellProduct(int Id);
        IList<Product> GetProduct();
    }
}
