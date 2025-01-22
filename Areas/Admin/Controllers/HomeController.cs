using FribergCarRentals_GOhman.Data;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentals_GOhman.Areas.Admin.Controllers
{
    [Area("Admin")]
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
