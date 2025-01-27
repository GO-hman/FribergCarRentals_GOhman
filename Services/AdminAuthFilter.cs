using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FribergCarRentals_GOhman.Services
{
    public class AdminAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(SessionHelper.CheckSession(filterContext.HttpContext))
            {
                var user = SessionHelper.GetUserFromSession(filterContext.HttpContext);
                var role = user.Role;
           
                if (role == null || role.ToString() != "Admin")
                {
                    filterContext.Result = new RedirectToActionResult("index", "Home", new { area = "" });
                }
            }
            else
            {
                filterContext.Result = new RedirectToActionResult("index", "Home", new { area = "" });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
