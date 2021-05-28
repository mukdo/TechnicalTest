using System;
using System.Collections.Generic;
using System.Text;
using TT.Data;

namespace TT.Library.Entity
{
    public class SellProduct : IEntity<int>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public IList<Product> Products { get; set; }
        public float SellingPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime SellingDate { get; set; }
    }
}
