using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;

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

        public Car GetCar(int id)
        {
            return carRepo.GetById(id);
        }

        public User GetUserById(int id)
        {
            return userRepo.GetById(id);
        }

    }
}
