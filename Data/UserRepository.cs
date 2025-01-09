using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Add(User user)
        {
            applicationDbContext.Users.Add(user);
            applicationDbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            applicationDbContext.Remove(user);
            applicationDbContext.SaveChanges();
        }
        public void Update(User user)
        {
            applicationDbContext.Update(user);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return applicationDbContext.Users.OrderBy(u => u.Id);
        }

        public User GetById(int id)
        {
            return applicationDbContext.Users.FirstOrDefault(u => u.Id == id);
        }

    }
}
