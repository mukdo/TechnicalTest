using System;
using System.Collections.Generic;
using System.Text;
using TT.Data;

namespace TT.Library.Entity
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PurchesPrice { get; set; }
        public int Quantity { get; set; }
        public SellProduct SellProduct { get; set; }
    }
}
