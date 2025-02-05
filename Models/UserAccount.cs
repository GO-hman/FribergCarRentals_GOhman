using FribergCarRentals_GOhman.Data;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals_GOhman.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string? FirstName { get; set; }
        [MaxLength(20)]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        public AccountRoles Role { get; set; } = AccountRoles.User;
    }
}
