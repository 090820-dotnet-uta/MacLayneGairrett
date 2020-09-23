using System;
using System.Collections.Generic;
using System.Text;

namespace P0.Models
{
    public class Inventories
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
