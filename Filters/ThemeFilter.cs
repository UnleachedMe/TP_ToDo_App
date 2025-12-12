using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GitDemoToDoApp.Filters
{
    public class ThemeFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var theme = context.HttpContext.Request.Cookies["Theme"] ?? "light";

            ((Controller)context.Controller).ViewBag.Theme = theme;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
