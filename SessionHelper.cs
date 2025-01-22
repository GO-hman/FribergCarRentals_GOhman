using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman
{
    public static class SessionHelper
    {
        public static bool CheckSession(HttpContext httpContext)
        {
            var session = httpContext.Session.GetString("LoggedInCookie");
            if (session != null)
            {

                var objectx = JsonConvert.DeserializeObject<JObject>(session);
                return true;
            }
            return false;
        }

        public static bool IsAdmin(HttpContext httpContext)
        {
            var session = httpContext.Session.GetString("LoggedInCookie");
            if (session != null)
            {
                var admin = JsonConvert.DeserializeObject<AdminAccount>(session);
                if (admin.IsAdmin)
                {
                    return true;
                }

            }
            return false;
        }

        public static UserAccount GetUserFromSession(HttpContext httpContext)
        {
            var session = httpContext.Session.GetString("LoggedInCookie");
            if (session != null)
            {
                var user = JsonConvert.DeserializeObject<UserAccount>(session);
                return user;
            }
            return null;
        }
    }
}
