using Gostie.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.Panel
{
    public class SalesInformationModel
    {
        public Order Order{ get; set; }
        public Customer Customer { get; set; }
        public ShippedStatus Status { get; set; }
    }
}
