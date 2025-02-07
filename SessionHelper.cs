using FribergCarRentals_GOhman.Models;
using Newtonsoft.Json;

namespace FribergCarRentals_GOhman
{
    public static class SessionHelper
    {
        public static bool CheckSessionLogin(HttpContext httpContext)
        {
            var session = httpContext.Session.GetString("LoggedInAccount");
            if (session != null)
            {
                return true;
            }
            return false;
        }
        public static bool IsAdmin(HttpContext httpContext)
        {
            var role = httpContext.Session.GetString("Role");
            if (role == "Admin")
                return true;
            return false;
        }

        public static UserAccount GetUserFromSession(HttpContext httpContext)
        {
            var session = httpContext.Session.GetString("LoggedInAccount");
            if (session != null)
            {
                var user = JsonConvert.DeserializeObject<UserAccount>(session);
                return user!;
            }
            return null!;
        }
    }
}
