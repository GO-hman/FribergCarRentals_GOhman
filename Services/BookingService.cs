using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FribergCarRentals_GOhman.Services
{
    public class BookingService
    {
        private readonly ICar carRepo;
        private readonly IUser userRepo;
        private readonly IBooking bookingRepo;

        public BookingService(ICar carRepo, IUser userRepo, IBooking bookingRepo)
        {
            this.carRepo = carRepo;
            this.userRepo = userRepo;
            this.bookingRepo = bookingRepo;
        }
        public List<Car> GetAllCars()
        {
            return carRepo.GetAll().ToList();
        }

        public List<UserAccount> GetAllUsers()
        {
            return userRepo.GetAll().ToList();
        }
        public Car GetCar(int id)
        {
            return carRepo.GetById(id);
        }
        public UserAccount GetUserById(int id)
        {
            return userRepo.GetById(id);
        }

        public List<Booking> GetBookingByUser(int id)
        {
            List<Booking> bookings = bookingRepo.GetAll().Where(b => b.User.Id == id).ToList() ?? new List<Booking>();
            return bookings;
        }
        public List<Car> GetAvailableCars(DateTime start, DateTime stop)
        {
            List<Car> availableCars = carRepo.GetAll().ToList();

            foreach (Booking b in bookingRepo.GetAll())
            {
                if (b.StartDate < stop && b.StopDate > start)
                    availableCars.Remove(b.Car);
            }
            return availableCars;
        }
        public bool IsCarAvailableAtDate(DateTime start, DateTime stop, int carId)
        {
            List<Car> availableCars = carRepo.GetAll().ToList();

            foreach (Booking b in bookingRepo.GetAll())
            {
                if (b.StartDate < stop && b.StopDate > start)
                    availableCars.Remove(b.Car);
            }

            return availableCars.Contains(GetCar(carId));
        }

        public List<SelectListItem> GetUserSelectList()
        {
            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (UserAccount user in userRepo.GetAll())
            {
                userList.Add(new SelectListItem { Text = user.Email, Value = user.Id.ToString() });
            }
            return userList;
        }
        public List<SelectListItem> GetCarSelectList()
        {
            List<SelectListItem> carList = new List<SelectListItem>();
            foreach (Car car in carRepo.GetAll())
            {
                carList.Add(new SelectListItem { Text = car.Model, Value = car.Id.ToString() });
            }
            return carList;
        }
    }
}
