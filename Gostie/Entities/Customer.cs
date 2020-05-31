using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Gostie.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public City City { get; set; }
        public string Phone { get; set; }
        public string Identity { get; set; }
    }
}
