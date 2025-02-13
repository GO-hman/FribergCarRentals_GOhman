using FribergCarRentals_DAL.Data;
using FribergCarRentals_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FribergCarRentals_GOhman.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUser userRepo;
        private readonly AuthLogin authLogin;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginController(IUser userRepo, AuthLogin authLogin, IHttpContextAccessor httpContextAccessor)
        {
            this.userRepo = userRepo;
            this.authLogin = authLogin;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAccount user)
        {
            UserAccount u = authLogin.GetUser(user.Email, user.Password);

            if (u is not null)
            {
                HttpContext.Session.SetString("LoggedInAccount", JsonConvert.SerializeObject(u));
                HttpContext.Session.SetString("Role", u.Role.ToString());
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(1);
                httpContextAccessor.HttpContext.Response.Cookies.Append("LoggedInCookie", JsonConvert.SerializeObject(u), options);

                if (HttpContext.Session.GetString("bookingLogin") == "booking")
                {
                    return RedirectToAction("SelectDate", "Booking");
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.NotFound = "Invalid username/password. Try again.";
            return View();
        }

        public IActionResult Logout()
        {
            try
            {
                httpContextAccessor.HttpContext.Response.Cookies.Delete("LoggedInCookie");
                string style = HttpContext.Session.GetString("style");
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("style", style);

                return RedirectToAction("Index", "Home", null);
            }
            catch
            {
                return RedirectToAction("Index", "Home", null);
            }
        }

        [HttpGet]
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
                    if(authLogin.CheckUsername(user.Email) != null)
                    {
                        ViewBag.UsernameError = "A user with that email is already registered";
                        return View();
                    }
                    userRepo.Add(user);
                    UserAccount currUser = authLogin.GetUser(user.Email, user.Password);
                    HttpContext.Session.SetString("LoggedInAccount", JsonConvert.SerializeObject(currUser));
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
