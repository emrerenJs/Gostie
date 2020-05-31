using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Gostie.Entities;
using Gostie.Models.Panel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using MailKit.Net.Smtp;
using Gostie.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Gostie.Controllers
{
    [Authorize(Roles="Admin")]
    public class ManagementController : Controller
    {
        private readonly GostieContext _context;
        private readonly AppIdentityDbContext _idcontext;
        public ManagementController(GostieContext context,AppIdentityDbContext idcontext)
        {
            _context = context;
            _idcontext = idcontext;
        }
        public IActionResult Index()
        {
            IndexPageModel model = new IndexPageModel();
            foreach(var item in _context.Categories)
            {
                model.Categories.Add(new SelectListItem
                {
                    Text = item.CategoryName,
                    Value = item.CategoryID.ToString()
                });
            }
            model.NavigationViewModel = new List<NavigationViewModel>();
            List<NavItem> navItems = (from navItem in _context.NavItems
                                      select navItem).ToList<NavItem>();
            foreach(var item in navItems)
            {
                model.NavigationViewModel.Add(new NavigationViewModel
                {
                    NavItem = item,
                    NavCategories = (from cat in _context.Categories
                                     join nav in _context.NavCategories
                                     on cat.CategoryID equals nav.Category.CategoryID
                                     where nav.NavItem.NavItemID == item.NavItemID
                                     select cat).ToList<Category>()
                });
            }
            model.Sliders = (
                from s in _context.Sliders
                select s                    
                ).ToList<Slider>();
            return View(model);
        }
        public IActionResult GetProducts()
        {
            var result = (from products in _context.Products
                         join categories in _context.Categories
                         on products.Category.CategoryID equals categories.CategoryID
                         select new ProductViewList {
                            product = products,
                            category = categories
                         }).ToList();
            List<Category> Categories = (from categories in _context.Categories
                             select categories).ToList<Category>();
            ProductsViewModel model = new ProductsViewModel();
            model.ProductList = result;
            model.product = new Product();
            model.category = new Category();
            model.Categories = new SelectList(Categories, "CategoryID", "CategoryName");
            return View(model);
        }
        public bool UploadFile(IFormFile file,int id,int who)
        {
            string pathname = "";
            if(who == 0)
            {
                 pathname = "products";
            }
            else if(who == 1)
            {
                pathname = "categories";
            }
            else
            {
                pathname = "sliders";
            }
            try
            {
                string fileName = id.ToString() + "_" + DateTime.Now.ToShortDateString() + file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + pathname, fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                if (who == 0)
                    _context.Products.Find(id).Picture = fileName;
                else if (who == 1)
                    _context.Categories.Find(id).Picture = fileName;
                else
                    _context.Sliders.Find(id).SliderImage = fileName;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, [FromForm(Name="ProductImage")]IFormFile image)
        {
            if (!ModelState.IsValid || image == null)
            {
                return View(product);
            }
            product.Category = _context.Categories.Find(product.Category.CategoryID);
            _context.Products.Add(product);
            _context.SaveChanges();
            int id = product.ProductID;
            if (UploadFile(image,id,0))
            {
                return RedirectToAction("GetProducts");
            }
            return View(product);
        }
        public async Task<IActionResult> AddCategory(Category category, [FromForm(Name= "CategoryImage")] IFormFile image)
        {
            if (!ModelState.IsValid || image == null)
            {
                return View(category);
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            int id = category.CategoryID;
            if (UploadFile(image, id,1))
            {
                return RedirectToAction("GetProducts");
            }
            return View(category);
        }
        public IActionResult AddSlider()
        {
            Slider slider = new Slider();
            return View(slider);
        }
        [HttpPost]
        public IActionResult AddSlider(Slider slider, [FromForm(Name="SliderImage")]IFormFile image)
        {
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            int id = slider.SliderID;
            if (UploadFile(image, id, 2))
            {
                return RedirectToAction("Index");
            }
            return View(slider);
        }
        [HttpPost]
        public IActionResult AddNavItem(string katalog, string[] Categories)
        {
            if (_context.NavItems.Count() >= 7)
            {
                return RedirectToAction("Index");
                //Hatalı durum
            }
            NavItem navItem = new NavItem
            {
                NavItemText = katalog
            };
            _context.NavItems.Add(navItem);
            _context.SaveChanges();
            foreach (var categoryItem in Categories)
            {
                Category category = _context.Categories.Find(int.Parse(categoryItem));
                _context.NavCategories.Add(new NavCategory
                {
                    NavItem = navItem,
                    Category = category
                });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult ViewDetails(Product product,string error="",int id = -1)
        {
            product.Category = (from products in _context.Products
                                join categories in _context.Categories
                                on products.Category.CategoryID equals categories.CategoryID
                                where products.ProductID == product.ProductID
                                select categories).FirstOrDefault();

            ProductUpdateModel model = new ProductUpdateModel
            {
                product = id != -1 ? _context.Products.Find(id) : product,
                Categories = new SelectList(_context.Categories,"CategoryID","CategoryName")
            };
            ViewBag.error = error;
            return View(model);
        }
        public IActionResult ViewCategoryDetails(int id,string error = "")
        {
            CategoryUpdateModel categoryUpdateModel = new CategoryUpdateModel { category = _context.Categories.Find(id) };
            ViewBag.error = error;
            return View(categoryUpdateModel);
        }
        public IActionResult ViewSliderDetails(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            return View(slider);
        }
        [HttpPost]
        public async Task<IActionResult>UpdateSlider(Slider slider,[FromForm(Name= "SliderUpdateImage")]IFormFile image)
        {
            Slider newSlider = _context.Sliders.Find(slider.SliderID);
            newSlider.SliderDescription = slider.SliderDescription;
            newSlider.SliderHeader = slider.SliderHeader;
            if (image != null)
            {
                if (newSlider.SliderImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/sliders", newSlider.SliderImage);
                    System.IO.File.Delete(path);
                    _context.SaveChanges();
                }
                if (UploadFile(image, newSlider.SliderID, 2))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");//Hatalı durum
                }
            }
            else
            {
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product, [FromForm(Name = "ProductUpdatedImage")]IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            Product newProduct = _context.Products.Find(product.ProductID);
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            newProduct.Quantity = product.Quantity;
            newProduct.Category = _context.Categories.Find(product.Category.CategoryID);
            newProduct.Description = product.Description;
            newProduct.Discount = product.Discount;
            if(image != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", newProduct.Picture);
                System.IO.File.Delete(path);
                _context.SaveChanges();
                if (UploadFile(image, product.ProductID,0))
                {
                    return RedirectToAction("GetProducts");
                }
                else
                {
                    return RedirectToAction("GetProducts");//Hatalı durum
                }
            }
            else
            {
                _context.SaveChanges();
                return RedirectToAction("GetProducts");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category, [FromForm(Name = "CategoryUpdatedImage")]IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            Category newCategory = _context.Categories.Find(category.CategoryID);
            newCategory.CategoryName = category.CategoryName;
            newCategory.Description = category.Description;
            if (image != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/categories", newCategory.Picture);
                System.IO.File.Delete(path);
                _context.SaveChanges();
                if (UploadFile(image, category.CategoryID, 1))
                {
                    return RedirectToAction("GetProducts");
                }
                else
                {
                    return RedirectToAction("GetProducts");//Hatalı durum
                }
            }
            else
            {
                _context.SaveChanges();
                return RedirectToAction("GetProducts");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            Product deletedProduct = _context.Products.Find(product.ProductID);
            try
            {
                _context.Products.Remove(deletedProduct);
                _context.SaveChanges();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", deletedProduct.Picture);
                System.IO.File.Delete(path);
                return RedirectToAction("GetProducts");
            }
            catch(Exception ex)
            {
                return RedirectToAction("ViewDetails",new { product, error = "Bu ürüne ait siparişler var, bu ürünü silemezsiniz..", id = product.ProductID});
            }

        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(Category category)
        {
            Category deletedCategory = _context.Categories.Find(category.CategoryID);
            try
            {
                _context.Categories.Remove(deletedCategory);
                _context.SaveChanges();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/categories", deletedCategory.Picture);
                System.IO.File.Delete(path);
                return RedirectToAction("GetProducts");
            }
            catch
            {
                return RedirectToAction("ViewCategoryDetails",new { id = category.CategoryID, error = "Bu kategoriye ait ürünler var veya bu kategori bir kataloğun içinde bulunuyor.."});
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteNavItem(int id)
        {
            List<NavCategory> result = (from navcats in _context.NavCategories
                          join nav in _context.NavItems
                          on navcats.NavItem.NavItemID equals nav.NavItemID
                          where nav.NavItemID == id 
                          select navcats
                          ).ToList<NavCategory>();
            foreach(NavCategory item in result)
            {
                _context.NavCategories.Remove(item);
                _context.SaveChanges();
            }
            NavItem itemNav = _context.NavItems.Find(id);
            _context.NavItems.Remove(itemNav);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteNavCategory(int navid,int catid)
        {
            NavCategory navCategory = (
                    from nav in _context.NavItems
                    join navcat in _context.NavCategories
                    on nav.NavItemID equals navcat.NavItem.NavItemID
                    join cat in _context.Categories
                    on navcat.Category.CategoryID equals cat.CategoryID
                    where navcat.Category.CategoryID == catid && nav.NavItemID == navid
                    select navcat
                ).FirstOrDefault();
            _context.NavCategories.Remove(navCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/sliders", slider.SliderImage);
            System.IO.File.Delete(path);
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Satışlar:Geçmiş siparişler, Güncel siparişler
        public IActionResult Sales(int num)
        {
            if(num > 3)
            {
                num = 1;
            }
            SalesViewModel model = new SalesViewModel();
            var result = from c in _context.Customers
                         join o in _context.Orders
                         on c.CustomerID equals o.Customer.CustomerID
                         join s in _context.ShippedStatusses
                         on o.ShippedStatus.ShippedStatusID equals s.ShippedStatusID
                         where s.ShippedStatusID == num
                         select new { o, c, s };
            model.SalesInformationModels = new List<SalesInformationModel>();
            foreach(var item in result)
            {
                model.SalesInformationModels.Add(new SalesInformationModel
                {
                    Customer = item.c,
                    Order = item.o,
                    Status = item.s
                });
            }
            return View(model);
        }
        public IActionResult SaleDetails(int orderid)
        {
            Order order = _context.Orders.Find(orderid);
            Shipper shipper = (from o in _context.Orders
                               join s in _context.Shippers
                               on o.Shipper.ShipperID equals s.ShipperID
                               where o.OrderID == order.OrderID
                               select s).FirstOrDefault();
            OrderNOrderedModel model = new OrderNOrderedModel
            {
                Order = order,
                Status = (from s in _context.ShippedStatusses
                          join o in _context.Orders
                          on s.ShippedStatusID equals o.ShippedStatus.ShippedStatusID
                          where o.OrderID == order.OrderID
                          select s).FirstOrDefault(),
                OrderDetail = (from od in _context.OrderDetails
                               join o in _context.Orders
                               on od.Order.OrderID equals o.OrderID
                               where o.OrderID == order.OrderID
                               select od
                                   ).FirstOrDefault(),
                Products = (from ods in _context.Ordereds
                            join o in _context.Orders
                            on ods.Order.OrderID equals o.OrderID
                            join p in _context.Products
                            on ods.Product.ProductID equals p.ProductID
                            where o.OrderID == order.OrderID
                            select p).ToList<Product>(),
                Customer = (from c in _context.Customers
                            join o in _context.Orders
                            on c.CustomerID equals o.Customer.CustomerID
                            where o.OrderID == order.OrderID
                            select c).FirstOrDefault(),
                Shippers = new SelectList((from s in _context.Shippers
                            select s),"ShipperID", "CompanyName"),
                Shipper = shipper == null ? new Shipper() : shipper,
                Complaints = (from cmp in _context.Complaints
                              join ordr in _context.Orders
                              on cmp.Order.OrderID equals ordr.OrderID
                              where ordr.OrderID == order.OrderID
                              select cmp).ToList<Complaint>(),
                Ordereds = (from ods in _context.Ordereds
                            join o in _context.Orders
                            on ods.Order.OrderID equals o.OrderID
                            join p in _context.Products
                            on ods.Product.ProductID equals p.ProductID
                            where o.OrderID == order.OrderID
                            select ods).ToList<Ordered>()
            };
            return View(model);
        }
        public IActionResult DeleteComplaint(int complaintid)
        {
            _context.Complaints.Remove(_context.Complaints.Find(complaintid));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateOrder(string description,Shipper shipper,int status,int orderid)
        {
            Order order = _context.Orders.Find(orderid);
            string identity = (from c in _context.Customers
                                 join o in _context.Orders
                                 on c.CustomerID equals o.Customer.CustomerID
                                 where o.OrderID == orderid
                                 select c.Identity).FirstOrDefault();
            if(status == 0)
            {
                //Sipariş iptali
                List<Ordered>result = (from ods in _context.Ordereds
                             join o in _context.Orders
                             on ods.Order.OrderID equals o.OrderID
                             where o.OrderID == order.OrderID
                             select ods).ToList<Ordered>();
                foreach(var item in result)
                {
                    _context.Ordereds.Remove(_context.Ordereds.Find(item.OrderedID));
                    _context.SaveChanges();
                }
                _context.Orders.Remove(order);
                _context.SaveChanges();

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Gostie", "testyazilimhesabi@gmail.com"));
                string email = (from u in _idcontext.Users
                               where u.Id == identity
                               select u.Email).FirstOrDefault();
                message.To.Add(new MailboxAddress("Sipariş iptali",email));
                message.Subject = description;
                message.Body = new TextPart("plain")
                {
                    Text = description
                };
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("yazilimtesthesabi@gmail.com", "yazilim1998");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            else if(status == 1)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Order = order,
                    TakeOffDate = DateTime.Now,
                    Description = description
                };
                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();
                order.Shipper = _context.Shippers.Find(shipper.ShipperID);
                order.ShippedStatus = _context.ShippedStatusses.Find(2);
                _context.SaveChanges();
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Gostie", "testyazilimhesabi@gmail.com"));
                string email = (from u in _idcontext.Users
                                where u.Id == identity
                                select u.Email).FirstOrDefault();
                message.To.Add(new MailboxAddress("Sipariş kargoya verildi",email));
                message.Subject = description;
                message.Body = new TextPart("plain")
                {
                    Text = description
                };
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("yazilimtesthesabi@gmail.com", "yazilim1998");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            else
            {
                order.ShippedStatus = _context.ShippedStatusses.Find(3);
                _context.SaveChanges();
            }
            return RedirectToAction("Sales");
        }
    }
}