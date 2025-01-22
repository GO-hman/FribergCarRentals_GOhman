using FribergCarRentals_GOhman.Data;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals_GOhman.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public AccountRoles Role { get; private set; } = AccountRoles.User;

        public bool IsAdmin { get; set; } = false;


        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();
    }


}
