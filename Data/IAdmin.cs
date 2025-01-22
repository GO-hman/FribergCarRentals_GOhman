using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public interface IAdmin
    {
        AdminAccount GetById(int id);
        IEnumerable<AdminAccount> GetAll();
        void Add(AdminAccount admin);
        void Update(AdminAccount admin);
        void Delete(AdminAccount admin);
    }
}
