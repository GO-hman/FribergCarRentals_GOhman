using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRentals_GOhman.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual User User { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual Car Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
    }
}
