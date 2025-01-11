namespace FribergCarRentals_GOhman.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Car Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
    }
}
