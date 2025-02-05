namespace FribergCarRentals_GOhman.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string ImgURL { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string ModelYear { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty;
        public string Gearbox { get; set; } = string.Empty;
        public int PricePerDay { get; set; }



    }
}
