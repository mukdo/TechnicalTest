using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TT.Library.Service;

namespace TechicalTest.Web.Areas.Admin.Models.SellProducts
{
    public class SellProductModel : SellProductBaseModel
    {
        public SellProductModel() : base() { }
        public SellProductModel(ISellProductService sellProductService) : base(sellProductService) { }

        internal object GetSellProduct(DataTablesAjaxRequestModel dataTables)
        {
            var data = _sellPoductService.GetSellProducts(
                                  dataTables.PageIndex,
                                   dataTables.PageSize,
                                  dataTables.SearchText,
                                  dataTables.GetSortText(new string[] { "Id", "productId", "SellingPrice", "SellingDate" , "Quantity" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.sellProducts
                        select new string[]
                        {
                                record.ProductId.ToString(),
                                record.SellingPrice.ToString(),
                                record.SellingDate.ToString(),
                                record.Quantity.ToString(),
                                record.Id.ToString()
    }
                   ).ToArray()

            };
        }
        internal string Delete(int Id)
        {
            var deleteSellProduct = _sellPoductService.DeleteSellProduct(Id);
            return deleteSellProduct.Id.ToString();

        }

        public IList<SelectListItem> GetProductList()
        {
            IList<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _sellPoductService.GetProduct())
            {
                var ctg = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItems.Add(ctg);
            }
            return listItems;
        }

    }
}
