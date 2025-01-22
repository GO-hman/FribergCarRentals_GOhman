using FribergCarRentals_GOhman.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals_GOhman.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserAccount> Users { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<AdminAccount> Admins { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
