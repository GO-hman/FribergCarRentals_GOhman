namespace FribergCarRentals_GOhman.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string ModelYear { get; set; }

        public string ImgURL { get; set; }

        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
