using System;
using System.Collections.Generic;
using System.Text;
using TT.Library.Entity;

namespace TT.Library.Service
{
    public class ProductService : IProductService
    {
        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public (IList<Product> products, int total, int totalDisplay) GetProducts(int pageindex, int Pagesize, string searchText, string sortText)
        {
            throw new NotImplementedException();
        }
    }
}
