namespace FribergCarRentals_GOhman.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Car Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
    }
}
