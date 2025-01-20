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

        public static User GetUserFromSession(HttpContext httpContext)
        {
            var session = httpContext.Session.GetString("LoggedInCookie");
            if (session != null)
            {
                var user = JsonConvert.DeserializeObject<User>(session);
                return user;
            }
            return null;
        }
    }
}
