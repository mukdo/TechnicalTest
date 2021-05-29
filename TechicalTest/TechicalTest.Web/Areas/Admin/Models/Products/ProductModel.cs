using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TT.Library.Service;

namespace TechicalTest.Web.Areas.Admin.Models.Products
{
    public class ProductModel : ProductBaseModel
    {
        public ProductModel() : base() { }
        public ProductModel(IProductService productService) : base( productService) { }

        internal object GetProduct(DataTablesAjaxRequestModel dataTables)
        {
            var data = _poductService.GetProducts(
                                  dataTables.PageIndex,
                                   dataTables.PageSize,
                                  dataTables.SearchText,
                                  dataTables.GetSortText(new string[] { "Id", "Name", "PurchesPrice", "Quantity" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.products
                        select new string[]
                        {
                                record.Name,
                                record.PurchesPrice.ToString(),
                                record.Quantity.ToString(),
                                record.Id.ToString()
    }
                   ).ToArray()

            };
        }
        internal string Delete(int Id)
        {
            var deleteProduct = _poductService.DeleteProduct(Id);
            return deleteProduct.Name;

        }

    }
}
