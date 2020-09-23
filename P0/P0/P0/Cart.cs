using System;
using System.Collections.Generic;
using System.Text;

namespace P0
{
    public class Cart
    {
        public List<int> LocationIds { get; set; }
        public int CustId { get; set; }
        public List<int> ProdIds { get; set; }
        public List<double> ProdPrice { get; set; }
        public List<int> OrderQuantity { get; set; }
        public double Total { get; set; }
        public List<string> ProdTitle { get; set; }
    }
}
