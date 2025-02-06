using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FribergCarRentals_GOhman.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!SessionHelper.CheckSessionLogin(HttpContext))
            {
                try
                {
                    string cookie = Request.Cookies["LoggedInCookie"];
                    HttpContext.Session.SetString("LoggedInAccount", cookie);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

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
    }
}
