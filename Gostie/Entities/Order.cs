using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public ShippedStatus ShippedStatus { get; set; }
        public Shipper Shipper { get; set; }
        public string CreditCart { get; set; }
    }
}
