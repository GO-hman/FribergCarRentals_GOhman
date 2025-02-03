using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using FribergCarRentals_GOhman.Services;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        // GET: BookingController
        public ActionResult Index()
        {
            return View(_bookingRepo.GetAll());
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
            if (bookingVM.StartDate > bookingVM.StopDate)
            {
                ViewBag.Error = "StartDate cant be higher than stopdate";
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
                return RedirectToAction("SelectCar", bookingVM);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SelectCar(BookingViewModel bookingVM)
        {
            bookingVM.Cars = _bookingService.GetAllCars();
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
            return View(_bookingRepo.GetById(id));
        }

        // GET: BookingController/Create
        public ActionResult Create(BookingViewModel bookingVM)
        {
            bookingVM.Car = _bookingService.GetCar(bookingVM.CarId);

            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (UserAccount user in _bookingService.GetAllUsers())
            {
                userList.Add(new SelectListItem { Text = user.Email, Value = user.Id.ToString() });
            }
            bookingVM.UserAccounts = userList;
            ViewBag.UserList = userList;
            return View(bookingVM);
        }

        // POST: BookingController/Create
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
                    b.Car = _bookingService.GetCar(tempBooking.CarId);
                    b.User = _bookingService.GetUserById((int)tempBooking.UserId);

                    _bookingRepo.Add(b);
                    HttpContext.Session.Remove("carID");
                }
                return RedirectToAction("Confirmation", b);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Confirmation(Booking booking)
        {
            return View(_bookingRepo.GetById(booking.Id));
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_bookingRepo.GetById(id));
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
                    _bookingRepo.Update(booking);
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
            return View();
        }

        // POST: BookingController/Delete/5
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
