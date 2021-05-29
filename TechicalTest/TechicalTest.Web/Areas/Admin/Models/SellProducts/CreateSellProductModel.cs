using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TT.Library.Entity;
using TT.Library.Service;

namespace TechicalTest.Web.Areas.Admin.Models.SellProducts
{
    public class CreateSellProductModel : SellProductBaseModel
    {
        public CreateSellProductModel() : base() { }
        public CreateSellProductModel(ISellProductService productService) : base(productService) { }
        
        [Required]
        public int ProductId { get; set; }
        [Required]
        public float SellingPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime SellingDate { get; set; }

        public void Create()
        {
            var sellProduct = new SellProduct()
            {
                ProductId = this.ProductId,
                Quantity = this.Quantity,
                SellingDate = this.SellingDate,
                SellingPrice = this.SellingPrice
            };
            _sellPoductService.CreateSellProduct(sellProduct);
        }

    }
}

