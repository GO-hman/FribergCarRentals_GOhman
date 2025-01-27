using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FribergCarRentals_GOhman.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuthLogin authLogin;

        public AdminController(AuthLogin authLogin)
        {
            this.authLogin = authLogin;
        }
        public IActionResult Login()
        {
            if (SessionHelper.CheckSession(HttpContext))
            {
                if (SessionHelper.IsAdmin(HttpContext))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginVM)
        {
            AdminAccount a = authLogin.GetAdmin(loginVM.Email, loginVM.Password);

            if (a is not null)
            {
                HttpContext.Session.SetString("LoggedInCookie", JsonConvert.SerializeObject(a));
                HttpContext.Session.SetString("Role", a.Role.ToString());
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
