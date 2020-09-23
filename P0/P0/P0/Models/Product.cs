using System;
using System.Collections.Generic;
using System.Text;

namespace P0.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string Maker { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{ProductId}\n{ProductTitle}\n{Maker}\n{Description}\n{Price}";
        }
    }
}
