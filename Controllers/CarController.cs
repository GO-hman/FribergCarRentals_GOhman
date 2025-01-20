using FribergCarRentals_GOhman.Data;
using Microsoft.AspNetCore.Http;
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
        // GET: CarController
        public ActionResult Index()
        {
            return View(carRepo.GetAll());
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View(carRepo.GetById(id));
        }
    }
}
