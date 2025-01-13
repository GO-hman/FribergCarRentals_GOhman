using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.ViewModels
{
    public class BookingViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Car Car { get; set; }
        public User User { get; set; }
    }
}
