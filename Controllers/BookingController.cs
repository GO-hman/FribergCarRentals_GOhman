using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            return View();
        }

        public ActionResult SelectDate()
        {
            BookingViewModel bookingVM = new BookingViewModel();
            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectDate(BookingViewModel bookingVM)
        {
            try
            {
                return RedirectToAction("SelectCar", bookingVM);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SelectCar(BookingViewModel bookingVM)
        {
            bookingVM.Cars = carRepository.GetAll().ToList();
            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectCar(BookingViewModel bookingVM, int id)
        {
            try
            {
                bookingVM.CarId = id;
                return RedirectToAction("Confirmation");
            }
            catch
            {
                return View();
            }
        }

        //// GET: BookingController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: BookingController/Create
        public ActionResult Create(BookingViewModel bookingVM)
        {
            
            return View(bookingVM);
        }

        //// POST: BookingController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(BookingViewModel tempBooking)
        //{
        //    try
        //    {
        //        Booking booking = new Booking();
        //        booking.StartDate = tempBooking.StartDate;
        //        booking.StopDate = tempBooking.StopDate;
        //        booking.Car = carRepository.GetById(tempBooking.CarId);
        //        booking.User = userRepository.GetById(1);
        //        //bookingVM.Car = carRepository.GetById(tempBooking.CarId);
        //        bookingRepository.Add(booking);
        //        return RedirectToAction(nameof(Confirmation));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult Confirmation()
        {
            Booking booking = bookingRepository.GetById(1);


            return View(booking);
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
