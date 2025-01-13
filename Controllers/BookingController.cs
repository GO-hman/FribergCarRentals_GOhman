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
        private BookingViewModel bookingVM = new BookingViewModel();

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
            bookingVM.Car = carRepository.GetById(id);
            return View(bookingVM);
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingViewModel tempBooking)
        {
            try
            {
                bookingVM.StartDate = tempBooking.StartDate;
                bookingVM.EndDate = tempBooking.EndDate;
                return RedirectToAction(nameof(Confirmation));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Confirmation(BookingViewModel bookingVM)
        {
            return View();
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
