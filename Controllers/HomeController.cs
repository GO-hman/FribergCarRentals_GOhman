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

        public HomeController(ILogger<HomeController> logger, MockData moockData)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            //var session = HttpContext.Session.GetString("LoggedInCookie");
            //if (session != null)
            //{

            //var objectx = JsonConvert.DeserializeObject<JObject>(session);
            //Console.WriteLine(objectx.ToString());
            //}

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
