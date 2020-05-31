using Gostie.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.Panel
{
    public class NavigationViewModel
    {
        public NavItem NavItem { get; set; }
        public List<Category> NavCategories { get; set; }
    }
}
