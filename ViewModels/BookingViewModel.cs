using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.ViewModels
{
    public class BookingViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public List<Car>? Cars { get; set; } = new List<Car>();
        public int CarId { get; set; }
        public Car? Car { get; set; }
    }
}
