using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MockData()
        {
            mock.MockUsers();
            mock.MockCars();
            return View();
        }

        public IActionResult Login()
        {
            if (SessionHelper.CheckSession(HttpContext))
            {
                if (SessionHelper.IsAdmin(HttpContext))
                {
                    return RedirectToAction(nameof(Index));
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
        public ActionResult Login(LoginViewModel loginVM)
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
    }
}
