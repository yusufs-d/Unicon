using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace Unicon.Filters
{
    public class RedirectIfNotLoggedInAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity != null && !context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "User", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
