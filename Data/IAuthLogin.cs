using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public interface IAuthLogin
    {
        UserAccount CheckUsername(string userName);
        bool CheckPassword(UserAccount user, string password);

        bool CheckAdmin(bool admin);
    }
}
