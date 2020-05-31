using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Entities
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public Order Order { get; set; }
        public DateTime TakeOffDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Description { get; set; }
    }
}
