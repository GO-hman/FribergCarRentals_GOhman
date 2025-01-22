using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public class AdminRepository: IAdmin
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Add(AdminAccount admin)
        {
            applicationDbContext.Admins.Add(admin);
            applicationDbContext.SaveChanges();
        }

        public void Delete(AdminAccount admin)
        {
            applicationDbContext.Remove(admin);
            applicationDbContext.SaveChanges();
        }
        public void Update(AdminAccount admin)
        {
            applicationDbContext.Update(admin);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<AdminAccount> GetAll()
        {
            return applicationDbContext.Admins.OrderBy(u => u.Id);
        }

        public AdminAccount GetById(int id)
        {
            return applicationDbContext.Admins.FirstOrDefault(u => u.Id == id);
        }
    }
}
