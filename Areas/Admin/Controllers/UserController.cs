using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentals_GOhman.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUser userRepository;

        public UserController(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View(userRepository.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(userRepository.GetById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userRepository.Add(user);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(userRepository.GetById(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userRepository.Update(user);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(userRepository.GetById(id));
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            try
            {
                userRepository.Delete(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
