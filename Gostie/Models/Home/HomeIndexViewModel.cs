using Gostie.Entities;
using Gostie.Models.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.Home
{
    public class HomeIndexViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> NewestProducts { get; set; }
    }
}
