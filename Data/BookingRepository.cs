using FribergCarRentals_GOhman.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals_GOhman.Data
{
    public class BookingRepository : IBooking
    {
        private readonly ApplicationDbContext appDbContext;

        public BookingRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void Add(Booking booking)
        {
            appDbContext.Bookings.Add(booking);
            appDbContext.SaveChanges();
        }

        public void Delete(Booking booking)
        {
            appDbContext.Bookings.Remove(booking);
            appDbContext.SaveChanges();
        }

        public IEnumerable<Booking> GetAll()
        {
            return appDbContext.Bookings.OrderBy(b=>b.StartDate);
        }

        public Booking GetById(int id)
        {
            return appDbContext.Bookings
                    .Include(b=>b.Car)
                    .Include(b=>b.User)
                    .FirstOrDefault(b => b.Id == id);
        }

        public void Update(Booking booking)
        {
            appDbContext.Update(booking);
            appDbContext.SaveChanges();
        }
    }
}
