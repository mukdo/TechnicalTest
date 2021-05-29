using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TT.Library.Entity;
using TT.Library.Service;

namespace TechicalTest.Web.Areas.Admin.Models.SellProducts
{
    public class EditSellProductModel : SellProductBaseModel
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public float SellingPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime SellingDate { get; set; }
        public EditSellProductModel() : base() { }
        public EditSellProductModel(ISellProductService sellProductService) : base(sellProductService) { }

        public void EditSellProduct()
        {
            var editSellProduct = new SellProduct()
            {
                Id = this.Id,
                ProductId = this.ProductId,
                Quantity = this.Quantity,
                SellingDate = this.SellingDate,
                SellingPrice = this.SellingPrice
            };
            _sellPoductService.EditSellProduct(editSellProduct);
        }

        internal void Load(int id)
        {
            var product = _sellPoductService.GetSellProduct(id);
            if (product != null)
            {
                Id = product.Id;
                ProductId = product.ProductId;
                Quantity = product.Quantity;
                SellingDate = product.SellingDate;
                SellingPrice = product.SellingPrice;
            }
        }
    }
}
