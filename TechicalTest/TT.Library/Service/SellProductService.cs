using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TT.Framework;
using TT.Library.Entity;

namespace TT.Library.Service
{
    public class SellProductService : ISellProductService
    {
        private ITTUnitOfWork _unitOfWork;

        public SellProductService( ITTUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateSellProduct(SellProduct product)
        {
            _unitOfWork.SellProductRepository.Add(product);
            _unitOfWork.Save();
        }

        public SellProduct DeleteSellProduct(int Id)
        {
            var sellProduct = _unitOfWork.SellProductRepository.GetById(Id);
            _unitOfWork.SellProductRepository.Remove(Id);
            _unitOfWork.Save();
            return sellProduct;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public void EditSellProduct(SellProduct product)
        {
            var updateSellProduct = _unitOfWork.SellProductRepository.GetById(product.Id);
            updateSellProduct.Quantity = product.Quantity;
            updateSellProduct.SellingDate = product.SellingDate;
            updateSellProduct.SellingPrice = product.SellingPrice;

            _unitOfWork.Save();
        }

        public SellProduct GetSellProduct(int Id)
        {
            return _unitOfWork.SellProductRepository.GetById(Id);
        }

        public (IList<SellProduct> sellProducts, int total, int totalDisplay) GetSellProducts(int pageindex, int Pagesize, string searchText, string sortText)
        {
            var result = _unitOfWork.SellProductRepository.GetAll().ToList();
            return (result, 0, 0);
        }

        public IList<Product> GetProduct()
        {
            return _unitOfWork.ProductRepository.GetAll();
        }
    }
}
