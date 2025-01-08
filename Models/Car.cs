namespace FribergCarRentals_GOhman.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Year { get; set; }
        public bool IsAvailable { get; set; }
    }
}
