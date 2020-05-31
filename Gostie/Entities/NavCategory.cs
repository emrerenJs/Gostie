using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Entities
{
    public class NavCategory
    {
        public int NavCategoryID { get; set; }
        public NavItem NavItem { get; set; }
        public Category Category { get; set; }
    }
}
