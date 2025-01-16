using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public interface IAuthLogin
    {
        User CheckUsername(string userName);

        bool CheckPassword(User user, string password);

        bool CheckAdmin(bool admin);
    }
}
