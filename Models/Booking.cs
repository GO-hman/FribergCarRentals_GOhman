namespace FribergCarRentals_GOhman.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public UserAccount User { get; set; }
        public Car Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool Active { get; set; } = false;
        public bool Consumed { get; set; } = false;
        public DateTime Returned { get; set; }
    }
}
