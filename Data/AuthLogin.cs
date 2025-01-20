using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public class AuthLogin : IAuthLogin
    {
        private readonly IUser userRepo;

        public AuthLogin(IUser userRepo)
        {
            this.userRepo = userRepo;
        }

        public User GetUser(string username, string password)
        {
            User user = CheckUsername(username);
            bool pass = CheckPassword(user, password);
            if (user == null || !pass)
            {
                return null;
            }
            return user;
            

        }
        public bool CheckAdmin(bool admin)
        {
            throw new NotImplementedException();
        }

        public bool CheckPassword(User user, string password)
        {
            if (user.Password == password)
            {
                return true;
            }
            else
                return false;
        }

        public User CheckUsername(string userName)
        {
            bool ok = false;
            User u = new User();

            u = userRepo.GetAll().Where(u => u.Email.Equals(userName)).FirstOrDefault()!;
            if (u != null)
            {
                return u;
            }
            else
                return null!;


        }
    }
}
