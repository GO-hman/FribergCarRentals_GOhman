using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FribergCarRentals_GOhman.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUser userRepo;
        private readonly AuthLogin authLogin;

        public LoginController(IUser userRepo, AuthLogin authLogin)
        {
            this.userRepo = userRepo;
            this.authLogin = authLogin;
        }
        // GET: AuthLogin
        public ActionResult Index()
        {
            return View();
        }

        // GET: AuthLogin/Details/5
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginVM)
        {
            UserAccount u = authLogin.GetUser(loginVM.Email, loginVM.Password);

            if (u is not null)
            {
                HttpContext.Session.SetString("LoggedInCookie", JsonConvert.SerializeObject(u));
                HttpContext.Session.SetString("Role", u.Role.ToString());

                if(HttpContext.Session.GetString("bookingLogin") == "booking")
                {
                    return RedirectToAction("SelectDate", "Booking");
                }
                return RedirectToAction("Index", "Home");
            }

            return NotFound();
        }

        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout(int id)
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home", null);
            }
            catch
            {
                return RedirectToAction("Index", "Home", null);
            }
        }

        public IActionResult Register()
        {
            return View(new UserAccount());
        }

        // POST: AuthLogin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserAccount user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userRepo.Add(user);
                    UserAccount currUser = authLogin.GetUser(user.Email, user.Password);
                    HttpContext.Session.SetString("LoggedInCookie", JsonConvert.SerializeObject(currUser));
                    HttpContext.Session.SetString("Role", currUser.Role.ToString());

                    if (HttpContext.Session.GetString("bookingLogin") == "booking")
                    {
                        return RedirectToAction("SelectDate", "Booking");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
