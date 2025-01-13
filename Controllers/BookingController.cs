using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentals_GOhman.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBooking bookingRepository;
        private readonly ICar carRepository;
        private readonly IUser userRepository;

        private Booking currBooking = new Booking();
        private BookingViewModel bookingVM;

        public BookingController(IBooking bookingRepository, ICar carRepository, IUser userRepository)
        {
            this.bookingRepository = bookingRepository;
            this.carRepository = carRepository;
            this.userRepository = userRepository;
        }
        // GET: BookingController
        public ActionResult Index()
        {
            return View(carRepository.GetAll());
        }

        //// GET: BookingController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: BookingController/Create
        public ActionResult Create(int id)
        {
            currBooking.Car = carRepository.GetById(id);
            return View(currBooking);
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Booking tempBooking)
        {
            try
            {
                currBooking.Car = tempBooking.Car;
                currBooking.StartDate = tempBooking.StartDate;
                currBooking.StopDate = tempBooking.StopDate;
                currBooking.User = userRepository.GetById(1);
                bookingRepository.Add(currBooking);
                return RedirectToAction(nameof(Confirmation));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Confirmation()
        {
            return View(bookingRepository.GetById(1));
        }

        //// GET: BookingController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: BookingController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: BookingController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: BookingController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
