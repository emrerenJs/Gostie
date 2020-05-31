using Gostie.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Gostie.Models.Panel
{
    public class ProductsViewModel
    {
        public ProductsViewModel()
        {
            ProductList = new List<ProductViewList>();
        }
        public List<ProductViewList> ProductList { get; set; }
        public SelectList Categories{ get; set; }
        public Product product { get; set; }
        public Category category { get; set; }
    }
}
