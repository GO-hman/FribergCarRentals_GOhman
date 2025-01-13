using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FribergCarRentals_GOhman.ViewModels
{
    public class BookingViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public List<SelectListItem> Cars { get; set; } = new List<SelectListItem>();
        public int CarId { get; set; }
        public User? User { get; set; }
    }
}
