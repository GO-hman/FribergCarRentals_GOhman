using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public interface IUser
    {
        UserAccount GetById(int id);
        IEnumerable<UserAccount> GetAll();
        void Add(UserAccount user);
        void Update(UserAccount user);
        void Delete(UserAccount user);
    }
}
