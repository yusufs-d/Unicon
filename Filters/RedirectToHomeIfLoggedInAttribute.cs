using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Unicon.Filters
{
    public class RedirectToHomeIfLoggedInAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity!= null && context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}