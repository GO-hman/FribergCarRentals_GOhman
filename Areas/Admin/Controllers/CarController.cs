using FribergCarRentals_DAL.Data;
using FribergCarRentals_DAL.Models;
using FribergCarRentals_GOhman.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FribergCarRentals_GOhman.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthFilter]
    public class CarController : Controller
    {
        private readonly ICar carRepository;

        public CarController(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(carRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(carRepository.GetById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.FuelType = new SelectList(Enum.GetValues(typeof(FuelType)));
            ViewBag.Gearbox = new SelectList(Enum.GetValues(typeof(Gearbox)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    carRepository.Add(car);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.FuelType = new SelectList(Enum.GetValues(typeof(FuelType)));
            ViewBag.Gearbox = new SelectList(Enum.GetValues(typeof(Gearbox)));
            return View(carRepository.GetById(id));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    carRepository.Update(car);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(carRepository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Car car)
        {
            try
            {
                carRepository.Delete(car);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
