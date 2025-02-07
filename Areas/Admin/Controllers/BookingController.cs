using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using FribergCarRentals_GOhman.Services;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentals_GOhman.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthFilter]
    public class BookingController : Controller
    {
        private readonly BookingService _bookingService;
        private readonly IBooking _bookingRepo;

        public BookingController(BookingService bookingService, IBooking bookingRepo)
        {
            _bookingService = bookingService;
            _bookingRepo = bookingRepo;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(_bookingRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_bookingRepo.GetById(id));
        }
        [HttpGet]
        public ActionResult Create(BookingViewModel bookingVM)
        {
            bookingVM.Car = _bookingService.GetCar(bookingVM.CarId);

            bookingVM.UserAccounts = _bookingService.GetUserSelectList();
            bookingVM.CarSelectList = _bookingService.GetCarSelectList();
            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingViewModel bookingVM, int id)
        {
            if (bookingVM.StartDate >= bookingVM.StopDate)
            {
                ViewBag.Error = "Start date must be earlier than the stop date";
                bookingVM.UserAccounts = _bookingService.GetUserSelectList();
                bookingVM.CarSelectList = _bookingService.GetCarSelectList();
                return View(bookingVM);
            }
            else if (bookingVM.StartDate < DateTime.Now.Date)
            {
                ViewBag.Error = "Starting date has passed already. Try Again!";
                bookingVM.UserAccounts = _bookingService.GetUserSelectList();
                bookingVM.CarSelectList = _bookingService.GetCarSelectList();
                return View(bookingVM);
            }
            else if (bookingVM.StopDate > DateTime.Now.AddYears(1))
            {
                ViewBag.Error = "Cannot book a year ahead. Try another stop date!";
                bookingVM.UserAccounts = _bookingService.GetUserSelectList();
                bookingVM.CarSelectList = _bookingService.GetCarSelectList();
                return View(bookingVM);
            }
            try
            {
                Booking b = new Booking();
                if (ModelState.IsValid)
                {
                    b.StartDate = bookingVM.StartDate;
                    b.StopDate = bookingVM.StopDate;
                    b.Car = _bookingService.GetCar(bookingVM.CarId);
                    b.User = _bookingService.GetUserById((int)bookingVM.UserId);

                    _bookingRepo.Add(b);
                }
                return RedirectToAction("Confirmation", b);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Confirmation(Booking b)
        {
            return View(_bookingRepo.GetById(b.Id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_bookingRepo.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Booking booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookingRepo.Update(booking);
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
            return View(_bookingRepo.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Booking booking)
        {
            try
            {
                _bookingRepo.Delete(booking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Activate(int id)
        {
            return View(_bookingRepo.GetById(id));
        }

        [HttpPost]
        public ActionResult Activate(Booking booking)
        {
            try
            {
                booking = _bookingRepo.GetById(booking.Id);
                booking.Active = true;
                _bookingRepo.Update(booking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ReturnBooking(int id)
        {
            Booking b = _bookingRepo.GetById(id);
            b.Active = false;
            b.Consumed = true;
            b.Returned = DateTime.Now;
            _bookingRepo.Update(b);
            return RedirectToAction(nameof(Index));
        }
    }
}
