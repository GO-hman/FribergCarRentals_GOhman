using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FribergCarRentals_GOhman.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MockData moockData;

        public HomeController(ILogger<HomeController> logger, MockData moockData)
        {
            _logger = logger;
            this.moockData = moockData;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        //public IActionResult MockData()
        //{
        //    moockData.MockCars();
        //    moockData.MockUsers();
        //    return View();
        //}

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
