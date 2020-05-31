using Gostie.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.Panel
{
    public class OrderNOrderedModel
    {
        public Order Order{ get; set; }
        public List<Product> Products { get; set; }
        public ShippedStatus Status { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public List<Ordered> Ordereds { get; set; }
        public Customer Customer { get; set; }
        public SelectList Shippers { get; set; }
        public Shipper Shipper { get; set; }
        public List<Complaint> Complaints { get; set; }
    }
}
