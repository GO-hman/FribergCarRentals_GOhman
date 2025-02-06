using FribergCarRentals_GOhman.Data;

namespace FribergCarRentals_GOhman.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string ImgURL { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string ModelYear { get; set; } = string.Empty;
        public FuelType FuelType { get; set; }
        public Gearbox Gearbox { get; set; }
        public int PricePerDay { get; set; }



    }
}
