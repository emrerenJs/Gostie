using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Entities
{
    public class Basket
    {
        public int BasketID { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
