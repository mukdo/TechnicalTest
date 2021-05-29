using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TT.Library.Entity;
using TT.Library.Service;

namespace TechicalTest.Web.Areas.Admin.Models.Products
{
    public class CreateProductModel : ProductBaseModel
    {
        public CreateProductModel() : base() { }
        public CreateProductModel(IProductService productService) : base(productService) { }
        
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public float PurchesPrice { get; set; }
        [Required]
        public int Quantity { get; set; }

        public void Create()
        {
            var product = new Product()
            {
                Name = this.Name,
                Quantity = this.Quantity,
                PurchesPrice = this.PurchesPrice
            };
            _poductService.CreateProduct(product);
        }

    }
}
