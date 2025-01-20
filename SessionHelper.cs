using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
    }
}
