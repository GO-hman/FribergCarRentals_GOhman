using FribergCarRentals_DAL.Data;
using FribergCarRentals_DAL.Models;
using FribergCarRentals_GOhman.Services;
using FribergCarRentals_GOhman.ViewModels;
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

        [HttpGet]
        public ActionResult Index()
        {
            if (SessionHelper.CheckSessionLogin(HttpContext))
            {
                int userID = SessionHelper.GetUserFromSession(HttpContext).Id;
                BookingViewModel bookingVM = new BookingViewModel();
                bookingVM.EarlierBookings = bookingService.GetBookingByUser(userID).Where(b => b.Consumed == true).ToList();
                bookingVM.ActiveBookings = bookingService.GetBookingByUser(userID).Where(b => b.Active == true).ToList();
                bookingVM.UpcomingBookings = bookingService.GetBookingByUser(userID).Where(b => b.Active == false && b.Consumed == false).ToList();
                return View(bookingVM);
            }
            return RedirectToAction("login", "login");
        }

        [HttpGet]
        public ActionResult SelectDate()
        {

            if (!SessionHelper.CheckSessionLogin(HttpContext))
            {
                HttpContext.Session.SetString("bookingLogin", "booking");
                return RedirectToAction("Login", "Login");
            }
            HttpContext.Session.Remove("bookingLogin");

            BookingViewModel bookingVM = new BookingViewModel();
            int parseId = 0;
            if (int.TryParse(HttpContext.Session.GetString("carId"), out parseId))
            {
                bookingVM.CarId = parseId;
            }
            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectDate(BookingViewModel bookingVM)
        {
            if (bookingVM.StartDate > bookingVM.StopDate || bookingVM.StartDate == bookingVM.StopDate)
            {
                ViewBag.Error = "Starting date cant be higher or the same as stop date";
                return View();
            }
            else if (bookingVM.StartDate < DateTime.Now.Date)
            {
                ViewBag.Error = "Starting date has passed already. Try Again!";
                return View();
            }
            else if (bookingVM.StopDate > DateTime.Now.AddYears(1))
            {
                ViewBag.Error = "Cannot book a year ahead. Try another stop date!";
                return View();
            }

            try
            {
                if (bookingVM.CarId == 0)
                {
                    return RedirectToAction("SelectCar", bookingVM);
                }
                else
                {
                    return RedirectToAction("Create", bookingVM);
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult SelectCar(BookingViewModel bookingVM)
        {
            bookingVM.Cars = bookingService.GetAvailableCars(bookingVM.StartDate, bookingVM.StopDate);
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

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(bookingRepo.GetById(id));
        }

        [HttpGet]
        public ActionResult Create(BookingViewModel bookingVM)
        {
            bookingVM.Car = bookingService.GetCar(bookingVM.CarId);
            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingViewModel bookingVM, int id)
        {
            if (!bookingService.IsCarAvailableAtDate(bookingVM.StartDate, bookingVM.StopDate, bookingVM.CarId))
            {
                return RedirectToAction(nameof(BookingError));
            }

            try
            {
                Booking b = new Booking();
                if (ModelState.IsValid)
                {
                    b.StartDate = bookingVM.StartDate;
                    b.StopDate = bookingVM.StopDate;
                    b.Car = bookingService.GetCar(bookingVM.CarId);
                    if (SessionHelper.CheckSessionLogin(HttpContext))
                    {
                        UserAccount u = SessionHelper.GetUserFromSession(HttpContext);
                        b.User = bookingService.GetUserById(u.Id);
                    }
                    else
                    {
                        return NotFound();
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(bookingRepo.GetById(id));
        }

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

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(bookingRepo.GetById(id));
        }

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

        [HttpGet]
        public IActionResult BookingError()
        {
            return View();
        }

        [HttpPost]
        public void ClearCarData()
        {
            HttpContext.Session.Remove("carId");
        }
    }
}
