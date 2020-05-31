using Gostie.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.Panel
{
    public class ProductUpdateModel
    {
        public Product product { get; set; }
        public SelectList Categories{ get; set; }
    }
}
