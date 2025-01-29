using FribergCarRentals_GOhman.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FribergCarRentals_GOhman.ViewModels
{
    public class BookingViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public List<Car>? Cars { get; set; } = new List<Car>();
        public int CarId { get; set; }
        public List<SelectListItem>? UserAccounts { get; set; }
        public Car? Car { get; set; }

        public int? UserId { get; set; }

        public List<Booking>? EarlierBookings { get; set; }
        public List<Booking>? CurrentBookings { get; set; }
        public List<Booking>? UpcomingBookings { get; set; }
    }
}
