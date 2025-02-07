using FribergCarRentals_GOhman.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FribergCarRentals_GOhman.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (!SessionHelper.CheckSessionLogin(HttpContext))
            {
                try
                {
                    string cookie = Request.Cookies["LoggedInCookie"]!;
                    HttpContext.Session.SetString("LoggedInAccount", cookie);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Toggle()
        {
            if (HttpContext.Session.GetString("style") == "retro")
            {
                HttpContext.Session.SetString("style", "new");
            }
            else
            {
                HttpContext.Session.SetString("style", "retro");
            }
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
