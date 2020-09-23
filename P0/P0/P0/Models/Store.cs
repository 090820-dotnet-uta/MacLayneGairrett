using System;
using System.Collections.Generic;
using System.Text;

namespace P0.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public int Inventory { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return $"{StoreId}\n{Location}\n{Inventory}";
        }
    }
}
