using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gostie.Identity;
using Gostie.Models.Panel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gostie.Controllers
{
    public class ManagerController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signInManager;
        public ManagerController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.name);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(model.name, model.password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Management");
                }
            }
            ModelState.AddModelError(String.Empty, "Kullanıcı adı/parola yanlış!");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Manager");
        }
    }
}