using FribergCarRentals_GOhman.Data;

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


    }
}
