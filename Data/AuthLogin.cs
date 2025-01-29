using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public class AuthLogin : IAuthLogin
    {
        private readonly IUser userRepo;
        private readonly IAdmin adminRepo;

        public AuthLogin(IUser userRepo, IAdmin adminRepo)
        {
            this.userRepo = userRepo;
            this.adminRepo = adminRepo;
        }

        public UserAccount GetUser(string username, string password)
        {
            UserAccount user = CheckUsername(username);
            if (user == null)
            {
                return null;
            }
            bool pass = CheckPassword(user, password);
            if (!pass)
            {
                return null;
            }
            return user;
        }
        public AdminAccount GetAdmin(string username, string password)
        {
            AdminAccount admin = CheckAdminName(username);
            if (admin is null)
            {
                return null;
            }
            bool pass = CheckPassword(admin, password);
            if (!pass)
            {
                return null;
            }
            return admin;

        }
        public bool CheckAdmin(bool admin)
        {
            throw new NotImplementedException();
        }

        public bool CheckPassword(UserAccount user, string password)
        {
            if (user.Password == password)
            {
                return true;
            }
            else
                return false;
        }
        public bool CheckPassword(AdminAccount admin, string password)
        {
            if (admin.Password == password)
            {
                return true;
            }
            else
                return false;
        }

        public UserAccount CheckUsername(string userName)
        {
            UserAccount u = new UserAccount();

            u = userRepo.GetAll().Where(u => u.Email.Equals(userName)).FirstOrDefault()!;
            if (u != null)
            {
                return u;
            }
            else
                return null!;
        }

        public AdminAccount CheckAdminName(string username)
        {
            AdminAccount a = new AdminAccount();

            a = adminRepo.GetAll().Where(a => a.Email.Equals(username)).FirstOrDefault()!;
            if (a != null)
            {
                return a;
            }
            else
                return null!;
        }
    }
}
