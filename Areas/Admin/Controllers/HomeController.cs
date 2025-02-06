using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using FribergCarRentals_GOhman.Services;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FribergCarRentals_GOhman.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly MockData mock;
        private readonly AuthLogin authLogin;

        public HomeController(MockData mock, AuthLogin authLogin)
        {
            this.mock = mock;
            this.authLogin = authLogin;
        }
        [AdminAuthFilter]
        public IActionResult Index()
        {
           
            return View();
        }
        [AdminAuthFilter]
        public IActionResult MockData()
        {
            mock.MockUsers();
            mock.MockCars();
            return View();
        }
        public IActionResult Login()
        {
            if (SessionHelper.CheckSessionLogin(HttpContext))
            {
                    return RedirectToAction("Index", "Home");
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
                HttpContext.Session.SetString("LoggedInAccount", JsonConvert.SerializeObject(a));
                HttpContext.Session.SetString("Role", a.Role.ToString());
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
