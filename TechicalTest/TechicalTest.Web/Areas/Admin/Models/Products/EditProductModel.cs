using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TT.Library.Entity;
using TT.Library.Service;

namespace TechicalTest.Web.Areas.Admin.Models.Products
{
    public class EditProductModel : ProductBaseModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public float PurchesPrice { get; set; }
        [Required]
        public int Quantity { get; set; }

        public EditProductModel() : base() { }
        public EditProductModel(IProductService productService) : base(productService) { }

        public void EditProduct()
        {
            var editProduct = new Product()
            {
                Id = this.Id,
                Name = this.Name,
                Quantity = this.Quantity,
                PurchesPrice = this.PurchesPrice
            };
            _poductService.EditProduct(editProduct);
        }

        internal void Load(int id)
        {
            var product = _poductService.GetProduct(id);
            if (product != null)
            {
                Id = product.Id;
                Name = product.Name;
                Quantity = product.Quantity;
                PurchesPrice = product.PurchesPrice;
            }
        }

    }
}
