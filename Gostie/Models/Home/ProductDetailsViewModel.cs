using Gostie.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.Home
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public Category Category { get; set; }
        public List<Product> SimiliarProducts { get; set; }
    }
}
