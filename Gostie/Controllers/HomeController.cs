using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gostie.Entities;
using Gostie.Models.Home;
using Gostie.Models.Panel;
using Microsoft.AspNetCore.Mvc;

namespace Gostie.Controllers
{
    public class HomeController : Controller
    {
        private readonly GostieContext _context;
        public HomeController(GostieContext context)
        {
            _context = context;
        }
        public List<NavigationViewModel> GetNavigation()
        {
            List<NavigationViewModel>navigationViewModelList = new List<NavigationViewModel>();
            List<NavItem> navItems = (from navItem in _context.NavItems
                                      select navItem).ToList<NavItem>();
            foreach (var item in navItems)
            {
                navigationViewModelList.Add(new NavigationViewModel
                {
                    NavItem = item,
                    NavCategories = (from cat in _context.Categories
                                     join nav in _context.NavCategories
                                     on cat.CategoryID equals nav.Category.CategoryID
                                     where nav.NavItem.NavItemID == item.NavItemID
                                     select cat).ToList<Category>()
                });
            }
            return navigationViewModelList;
        }
        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            ViewData["NavigationViewModel"] = GetNavigation();
            model.Sliders = (from s in _context.Sliders select s).ToList<Slider>();
            model.Categories = _context.Categories.ToList<Category>();
            model.NewestProducts = _context.Products.OrderByDescending(p => p.ProductID).Take(12).ToList<Product>();
            return View(model);
        }
        public IActionResult Products(string key)
        {
            ViewData["NavigationViewModel"] = GetNavigation();
            HomeProductViewModel model = new HomeProductViewModel();
            model.Products = _context.Products
                .Where(p=>p.Name.Contains(key))
                .ToList<Product>();
            model.Key = key;
            return View(model);
        }
        public IActionResult Category(int category)
        {
            ViewData["NavigationViewModel"] = GetNavigation();
            HomeProductViewModel model = new HomeProductViewModel();
            model.Products = (
                    from p in _context.Products
                    join c in _context.Categories
                    on p.Category.CategoryID equals c.CategoryID
                    where c.CategoryID == category
                    select p
                ).ToList<Product>();
            model.category = _context.Categories.Find(category);
            return View("Products",model);
        }
        public IActionResult ProductDetails(int id)
        {
            ViewData["NavigationViewModel"] = GetNavigation();
            Product product = _context.Products.Find(id);
            Category category = (from c in _context.Categories
                                 join p in _context.Products
                                 on c.CategoryID equals p.Category.CategoryID
                                 where p.ProductID == id
                                 select c).FirstOrDefault();
            ProductDetailsViewModel model = new ProductDetailsViewModel
            {
                Product = product,
                Category = category
            };
            model.SimiliarProducts = (
                    from p in _context.Products
                    join c in _context.Categories
                    on p.Category.CategoryID equals c.CategoryID
                    where c.CategoryID == category.CategoryID
                    select p
                ).Take(12).ToList<Product>();
            return View(model);
        }
    }
}