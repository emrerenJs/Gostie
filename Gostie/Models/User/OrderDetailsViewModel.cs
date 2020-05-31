using Gostie.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.User
{
    public class OrderDetailsViewModel
    {
        public Customer Customer { get; set; }
        public ShippedStatus Status { get; set; }
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public List<Product> Products { get; set; }
        public List<Ordered> Ordereds { get; set; }

    }
}
