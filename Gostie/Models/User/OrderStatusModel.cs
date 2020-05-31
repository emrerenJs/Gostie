using Gostie.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.User
{
    public class OrderStatusModel
    {
        public Order Order{ get; set; }
        public ShippedStatus Status { get; set; }
    }
}
