using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
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
        public ActionResult Login(User user)
        {
            User u = authLogin.GetUser(user.Email, user.Password);
            if (u != null)
            {
                HttpContext.Session.SetString("LoggedInCookie", JsonConvert.SerializeObject(u));

                return RedirectToAction("Index");

            }
            return NotFound();
        }

        // POST: AuthLogin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthLogin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthLogin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthLogin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthLogin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
