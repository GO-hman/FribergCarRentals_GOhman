using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.ViewModels
{
    public class UserViewModel
    {
        private readonly IUser userRepo;
        private readonly IAdmin adminRepo;

        public UserViewModel(IUser userRepo, IAdmin adminRepo)
        {
            this.userRepo = userRepo;
            this.adminRepo = adminRepo;
            Users = userRepo.GetAll().ToList();
            Admins = adminRepo.GetAll().ToList();
        }
        public List<UserAccount> Users { get; set; }
        public List<AdminAccount> Admins { get; set; }
    }
}
