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
                                  dataTables.GetSortText(new string[] {"productId", "SellingPrice", "SellingDate" , "Quantity" , "Id" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.sellProducts
                        select new string[]
                        {
                                record.ProductId.ToString(),
                                record.SellingPrice.ToString(),
                                record.Quantity.ToString(),
                                record.SellingDate.ToString(),
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

      

    }
}
