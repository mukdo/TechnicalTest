using System;
using System.Collections.Generic;
using System.Text;
using TT.Library.Entity;

namespace TT.Library.Service
{
    public interface IProductService : IDisposable
    {
        (IList<Product> products, int total, int totalDisplay) GetProducts(int pageindex,
                                                                          int Pagesize,
                                                                          string searchText,
                                                                          string sortText);
        void CreateProduct(Product product);
        void EditProduct(Product product);
        Product GetProduct(int Id);
        Product DeleteProduct(int Id);
    }
}
