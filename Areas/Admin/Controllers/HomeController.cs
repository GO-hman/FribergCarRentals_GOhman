using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using FribergCarRentals_GOhman.Services;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FribergCarRentals_GOhman.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthFilter]
    public class HomeController : Controller
    {
        private readonly MockData mock;

        public HomeController(MockData mock)
        {
            this.mock = mock;
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

    }
}
