using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Services;
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

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
