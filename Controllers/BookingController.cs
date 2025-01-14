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
            bookingVM.CarId = id;
            List<Car> cars = carRepository.GetAll().ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var car in cars)
            {
                items.Add(new SelectListItem { Value=car.Id.ToString(), Text= car.Model});
            }
            bookingVM.Cars = items;
            
            return View(bookingVM);
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingViewModel tempBooking)
        {
            try
            {
                Booking booking = new Booking();
                booking.StartDate = tempBooking.StartDate;
                booking.StopDate = tempBooking.StopDate;
                booking.Car = carRepository.GetById(tempBooking.CarId);
                booking.User = userRepository.GetById(1);
                //bookingVM.Car = carRepository.GetById(tempBooking.CarId);
                bookingRepository.Add(booking);
                return RedirectToAction(nameof(Confirmation));
            }
            catch
            {
                return View();
            }
        }

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
