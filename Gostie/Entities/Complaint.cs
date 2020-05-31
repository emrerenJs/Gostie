using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Entities
{
    public class Complaint
    {
        public int ComplaintID { get; set; }
        public string ComplaintHeader { get; set; }
        public string ComplaintDescription { get; set; }
        public Order Order { get; set; }
    }
}
