using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Gostie.Entities;
using Gostie.Identity;
using Gostie.Models.User;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;

namespace Gostie.Controllers
{
    public class UserController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signInManager;
        private RoleManager<AppIdentityRole> _roleManager;
        private GostieContext _gostieContext;
        public UserController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, RoleManager<AppIdentityRole> roleManager, GostieContext gostieContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _gostieContext = gostieContext;
            _roleManager = roleManager;
        }
        public IActionResult Login(string message = "")
        {
            if (message != "")
                ViewBag.message = message;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user != null)
            {
                if(!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(String.Empty,"Email onayı gerekli..");
                    return View(model);
                }
                var result = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,false,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Account","User");
                }
                ModelState.AddModelError(String.Empty, "Kullanıcı adı/parola yanlış!");
            }
            ModelState.AddModelError(String.Empty, "Kullanıcı adı/parola yanlış!");
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.ConfirmPassword != model.Password)
            {
                ModelState.AddModelError(String.Empty, "Parolalar uyuşmuyor!");
                return View(model);
            }
            var name = await _userManager.FindByNameAsync(model.UserName);
            if(name != null)
            {
                ModelState.AddModelError(String.Empty, "Bu kullanıcı adı daha önce alınmış.");
                return View(model);
            }
            var user = new AppIdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var result2 = await _userManager.AddToRoleAsync(user, "User");
                _gostieContext.Customers.Add(new Customer
                {
                    Identity = user.Id
                });
                _gostieContext.SaveChanges();
                var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);
                
                var callBackUrl = Url.Action("ConfirmEmail", "User",new { userID = user.Id, code = confirmationCode.Result });
                /*Email*/
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Email onayı", "testyazilimhesabi@gmail.com"));
                message.To.Add(new MailboxAddress("Email onayı",user.Email));
                message.Subject = "Gostie e-mail onayı";
                message.Body = new TextPart("plain")
                {
                    Text = "Giriş yapabilmek için email onayı gerekmekte. Aşağıdaki linkten yapabilirsiniz;\n " + callBackUrl
                };
                using(var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("yazilimtesthesabi@gmail.com", "yazilim1998");
                    client.Send(message);
                    client.Disconnect(true);
                }
                /*Email*/
                return RedirectToAction("Login","User",new { message = "Kaydınız oluşturulmuştur. Lütfen Mail kutunuzu kontrol edin." });

            }
            ModelState.AddModelError(String.Empty, "Parolanız bir büyük harf, bir işaret(.,!*) ve bir rakam içermelidir.");
            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string userID,string code)
        {
            if(userID == null || code == null)
            {
                return RedirectToAction("Login");//hata
            }
            var user = await _userManager.FindByIdAsync(userID);
            if(user == null)
            {
                throw new ApplicationException("Kullanıcı bulunamadı..");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Login");//hata
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [Authorize(Roles="User")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "User");
        }
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Account()
        {
            Customer customer = (from c in _gostieContext.Customers
                                 where c.Identity == User.FindFirstValue(ClaimTypes.NameIdentifier)
                                 select c).FirstOrDefault();
            City city = (from c in _gostieContext.Customers
                        join ct in _gostieContext.Cities
                        on c.City.CityID equals ct.CityID
                        where c.Identity == User.FindFirstValue(ClaimTypes.NameIdentifier)
                        select ct).FirstOrDefault();
            AccountViewModel model = new AccountViewModel();
            model.Customer = customer;
            model.City = city;
            model.Cities = new SelectList(
                    _gostieContext.Cities,
                    "CityID", "Name"
                );
            return View(model);
        }
        [Authorize(Roles = "User")]
        public IActionResult Basket()
        {
            BasketViewModel model = new BasketViewModel();
            model.BasketProductList = new List<BasketProductModel>();
            var result = (
                    from p in _gostieContext.Products
                    join b in _gostieContext.Baskets
                    on p.ProductID equals b.Product.ProductID
                    join c in _gostieContext.Customers
                    on b.Customer.CustomerID equals c.CustomerID
                    where c.Identity == User.FindFirstValue(ClaimTypes.NameIdentifier)
                    select new { p, b }
                );
            foreach(var item in result)
            {
                model.BasketProductList.Add(new BasketProductModel(item.b, item.p));
            }
            return View(model);
        }
        [Authorize(Roles = "User")]
        public IActionResult Orders()
        {
            OrdersViewModel model = new OrdersViewModel();
            var result = from o in _gostieContext.Orders
                         join s in _gostieContext.ShippedStatusses
                         on o.ShippedStatus.ShippedStatusID equals s.ShippedStatusID
                         join c in _gostieContext.Customers
                         on o.Customer.CustomerID equals c.CustomerID
                         where c.Identity == User.FindFirstValue(ClaimTypes.NameIdentifier)
                         select new { o, s };
            model.Orders = new List<OrderStatusModel>();
            foreach(var item in result)
            {
                model.Orders.Add(new OrderStatusModel
                {
                    Order = item.o,
                    Status = item.s
                });
            }
            return View(model);
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult OrderDetails(int id)
        {
            OrderDetailsViewModel model = new OrderDetailsViewModel();
            model.Order = _gostieContext.Orders.Find(id);
            model.Customer = (
                from c in _gostieContext.Customers
                where c.Identity == User.FindFirstValue(ClaimTypes.NameIdentifier)
                select c
                ).FirstOrDefault();
            model.Status = (from o in _gostieContext.Orders
                           join s in _gostieContext.ShippedStatusses
                           on o.ShippedStatus.ShippedStatusID equals s.ShippedStatusID
                           where o.OrderID == id
                           select s).FirstOrDefault();
            model.OrderDetail = (
                    from o in _gostieContext.Orders
                    join od in _gostieContext.OrderDetails
                    on o.OrderID equals od.Order.OrderID
                    where o.OrderID == id
                    select od
                ).FirstOrDefault();
            model.Products = (
                    from o in _gostieContext.Orders
                    join os in _gostieContext.Ordereds
                    on o.OrderID equals os.Order.OrderID
                    join p in _gostieContext.Products
                    on os.Product.ProductID equals p.ProductID
                    where o.OrderID == id
                    select p
                ).ToList<Product>();
            model.Ordereds = (
                from o in _gostieContext.Orders
                join os in _gostieContext.Ordereds
                on o.OrderID equals os.Order.OrderID
                join p in _gostieContext.Products
                on os.Product.ProductID equals p.ProductID
                where o.OrderID == id
                select os
            ).ToList<Ordered>();
            return View(model);
        }
        [Authorize(Roles = "User")]
        public IActionResult AddToBasket(int id)
        {
            Product product = _gostieContext.Products.Find(id);
            Customer customer = (from c in _gostieContext.Customers
                                 where c.Identity == User.FindFirstValue(ClaimTypes.NameIdentifier)
                                 select c).FirstOrDefault();
            _gostieContext.Baskets.Add(new Basket
            {
                Customer = customer,
                Product = product,
                Count = 1
            });
            _gostieContext.SaveChanges();
            return RedirectToAction("Basket");
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult DeleteFromBasket(int id)
        {
            _gostieContext.Baskets.Remove(_gostieContext.Baskets.Find(id));
            _gostieContext.SaveChanges();
            return RedirectToAction("Basket");
        }
        [Authorize(Roles = "User")]
        public IActionResult Payment()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult MakeComplaint(int orderid,string complaintHeader,string complaint)
        {
            Order order = _gostieContext.Orders.Find(orderid);
            _gostieContext.Complaints.Add(new Complaint
            {
                Order = order,
                ComplaintHeader = complaintHeader,
                ComplaintDescription = complaint

            });
            _gostieContext.SaveChanges();
            return RedirectToAction("Account");
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult GiveOrder()
        {
            List<Basket> baskets = (from b in _gostieContext.Baskets
                         join c in _gostieContext.Customers
                         on b.Customer.CustomerID equals c.CustomerID
                         where c.Identity == User.FindFirstValue(ClaimTypes.NameIdentifier)
                         select b).ToList<Basket>();
            Customer customer = (from c in _gostieContext.Customers
                                 where c.Identity == User.FindFirstValue(ClaimTypes.NameIdentifier)
                                 select c).FirstOrDefault();
            //Sipariş açılıyor.
            Order order = new Order
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                ShippedStatus = _gostieContext.ShippedStatusses.Where(s => s.Status.Contains("Paketleme")).FirstOrDefault(),
                CreditCart = "x"
            };
            _gostieContext.Orders.Add(order);
            _gostieContext.SaveChanges();
            //Basketler siparişlere aktarılıyor.
            foreach(Basket basket in baskets)
            {
                Product product = (from b in _gostieContext.Baskets
                                  join p in _gostieContext.Products
                                  on b.Product.ProductID equals p.ProductID
                                  where b.BasketID == basket.BasketID
                                  select p).FirstOrDefault();
                _gostieContext.Ordereds.Add(new Ordered
                {
                    Order = order,
                    Product = product,
                    Count = basket.Count
                });
                _gostieContext.SaveChanges();
                Product updateProduct = _gostieContext.Products.Find(product.ProductID);
                updateProduct.Quantity = updateProduct.Quantity - 1;
                _gostieContext.SaveChanges();
                _gostieContext.Baskets.Remove(basket);
                _gostieContext.SaveChanges();
            }
            return RedirectToAction("Orders");
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult EditCustomer(Customer customer,City city)
        {
            Customer newCustomer = _gostieContext.Customers.Find(customer.CustomerID);
            newCustomer.Identity = User.FindFirstValue(ClaimTypes.NameIdentifier);
            newCustomer.Adress1 = customer.Adress1;
            newCustomer.Adress2 = customer.Adress2;
            newCustomer.FirstName = customer.FirstName;
            newCustomer.LastName = customer.LastName;
            newCustomer.Phone = customer.Phone;
            City newCity = _gostieContext.Cities.Find(city.CityID);
            newCustomer.City = newCity;
            _gostieContext.SaveChanges();
            return RedirectToAction("Account");
        }
        public IActionResult stat404()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult ChangeProductCount(int bid, int pcount)
        {
            _gostieContext.Baskets.Find(bid).Count = pcount;
            _gostieContext.SaveChanges();
            return RedirectToAction("Basket");
        }
    }
}