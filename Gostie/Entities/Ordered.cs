using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Entities
{
    public class Ordered
    {
        public int OrderedID { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
