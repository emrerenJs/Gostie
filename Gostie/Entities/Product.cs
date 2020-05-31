using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Picture { get; set; }
        public int Discount { get; set; }
    }
}
