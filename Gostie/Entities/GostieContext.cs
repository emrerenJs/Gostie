using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace Gostie.Entities
{
    public class GostieContext:DbContext
    {
        public GostieContext(DbContextOptions<GostieContext> option) : base(option) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordered> Ordereds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShippedStatus> ShippedStatusses { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<NavItem> NavItems { get; set; }
        public DbSet<NavCategory> NavCategories { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Basket> Baskets { get; set; }

    }
}
