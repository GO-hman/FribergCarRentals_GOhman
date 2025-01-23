﻿using Newtonsoft.Json.Linq;
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
