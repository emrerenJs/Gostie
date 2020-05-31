using Gostie.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.User
{
    public class AccountViewModel
    {
        public Customer Customer { get; set; }
        public SelectList Cities{ get; set; }
        public City City { get; set; }
    }
}
