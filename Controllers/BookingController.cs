using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using FribergCarRentals_GOhman.Services;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentals_GOhman.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingService bookingService;
        private readonly IBooking bookingRepo;

        public BookingController(BookingService bookingService, IBooking bookingRepo)
        {
            this.bookingService = bookingService;
            this.bookingRepo = bookingRepo;
        }
        // GET: BookingController
        public ActionResult Index()
        {
            if(SessionHelper.CheckSession(HttpContext))
            {
                return View(bookingService.GetBookingByUser(SessionHelper.GetUserFromSession(HttpContext).Id));

            }
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
            bookingVM.Cars = bookingService.GetAllCars();
            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectCar(BookingViewModel bookingVM, int id)
        {
            try
            {
                bookingVM.CarId = id;
                return RedirectToAction("Create", bookingVM);
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View(bookingRepo.GetById(id));
        }

        // GET: BookingController/Create
        public ActionResult Create(BookingViewModel bookingVM)
        {
            bookingVM.Car = bookingService.GetCar(bookingVM.CarId);
            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingViewModel tempBooking, int id)
        {
            try
            {
                Booking b = new Booking();
                if (ModelState.IsValid)
                {
                    b.StartDate = tempBooking.StartDate;
                    b.StopDate = tempBooking.StopDate;
                    b.Car = bookingService.GetCar(tempBooking.CarId);
                    if (SessionHelper.CheckSession(HttpContext))
                    {
                        UserAccount u = SessionHelper.GetUserFromSession(HttpContext);
                        b.User = bookingService.GetUserById(u.Id);
                    }
                    else
                    {
                        b.User = bookingService.GetUserById(1);
                    }

                    bookingRepo.Add(b);
                }
                return RedirectToAction("Confirmation", b);
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(bookingRepo.GetById(id));
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Booking booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookingRepo.Update(booking);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bookingRepo.GetById(id));
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Booking booking)
        {
            try
            {
                bookingRepo.Delete(booking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Confirmation(Booking booking)
        {
            return View(bookingRepo.GetById(booking.Id));
        }
    }
}
