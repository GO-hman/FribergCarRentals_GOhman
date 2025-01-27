using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using FribergCarRentals_GOhman.Services;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentals_GOhman.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthFilter]
    public class UserController : Controller
    {
        private readonly IUser userRepository;
        private readonly IAdmin adminRepository;
        private readonly UserViewModel userVM;

        public UserController(IUser userRepository, IAdmin adminRepository, UserViewModel userVM)
        {
            this.userRepository = userRepository;
            this.adminRepository = adminRepository;
            this.userVM = userVM;
        }

        public ActionResult Index()
        {
            return View(userVM);
        }

        public ActionResult Details(AdminAccount acc)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAccount user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (user.IsAdmin)
                    {
                        AdminAccount admin = new AdminAccount
                        {
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            Password = user.Password,
                            IsAdmin = user.IsAdmin
                        };
                        adminRepository.Add(admin);
                    }
                    else
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
        public ActionResult Edit(UserAccount user)
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
        public ActionResult Delete(UserAccount user)
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
