using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TT.Framework;
using TT.Library.Entity;

namespace TT.Library.Service
{
    public class ProductService : IProductService
    {
        private ITTUnitOfWork _unitOfWork;

        public ProductService(ITTUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateProduct(Product product)
        {
            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Save();
        }

        public Product DeleteProduct(int Id)
        {
            var product = _unitOfWork.ProductRepository.GetById(Id);
            _unitOfWork.ProductRepository.Remove(Id);
            _unitOfWork.Save();
            return product;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public void EditProduct(Product product)
        {
            var updateProduct = _unitOfWork.ProductRepository.GetById(product.Id);
            updateProduct.Quantity = product.Quantity;
            updateProduct.PurchesPrice = product.PurchesPrice;
            updateProduct.Name = product.Name;

            _unitOfWork.Save();
        }

        public Product GetProduct(int Id)
        {
            return _unitOfWork.ProductRepository.GetById(Id);
        }

        public (IList<Product> products, int total, int totalDisplay) GetProducts(int pageindex, int Pagesize, string searchText, string sortText)
        {
            var result = _unitOfWork.ProductRepository.GetAll().ToList();
            return (result, 0, 0);
        }
    }
}
