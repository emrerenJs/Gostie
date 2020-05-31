using Gostie.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.Home
{
    public class HomeProductViewModel
    {
        public List<Product> Products { get; set; }
        public Category category { get; set; }
        public string Key { get; set; }
    }
}
