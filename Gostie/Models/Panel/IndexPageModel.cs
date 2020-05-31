using Gostie.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.Panel
{
    public class IndexPageModel
    {
        public IndexPageModel()
        {
            Categories = new List<SelectListItem>();
        }
        public List<SelectListItem> Categories { get; set; }
        public List<NavigationViewModel> NavigationViewModel { get; set; }
        public List<Slider> Sliders { get; set; }
    }
}
