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
        public void Add(UserAccount user)
        {
            applicationDbContext.Users.Add(user);
            applicationDbContext.SaveChanges();
        }
        public void Delete(UserAccount user)
        {
            applicationDbContext.Remove(user);
            applicationDbContext.SaveChanges();
        }
        public void Update(UserAccount user)
        {
            applicationDbContext.Update(user);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return applicationDbContext.Users.OrderBy(u => u.Id);
        }

        public UserAccount GetById(int id)
        {
            return applicationDbContext.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
