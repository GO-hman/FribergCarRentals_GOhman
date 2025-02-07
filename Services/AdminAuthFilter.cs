using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FribergCarRentals_GOhman.Services
{
    public class AdminAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionHelper.CheckSessionLogin(filterContext.HttpContext))
            {
                var role = SessionHelper.IsAdmin(filterContext.HttpContext);
                if (!role)
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
