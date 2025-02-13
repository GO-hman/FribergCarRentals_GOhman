using FribergCarRentals_DAL.Data;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentals_GOhman.Controllers
{
    public class CarController : Controller
    {
        private readonly ICar carRepo;

        public CarController(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(carRepo.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(carRepo.GetById(id));
        }

        public IActionResult BookCar(int id)
        {
            HttpContext.Session.SetString("carId", id.ToString());
            return RedirectToAction("SelectDate", "Booking");
        }
    }
}
