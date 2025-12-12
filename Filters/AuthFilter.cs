using GitDemoToDoApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GitDemoToDoApp.Filters
{
    public class AuthFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Ne pas appliquer le filtre global au UserController
            /*
            if (context.Controller.GetType() == typeof(UserController))
                return;
            */

            var username = context.HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(username))
            {
                context.Result = new RedirectToActionResult("Login", "User", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
