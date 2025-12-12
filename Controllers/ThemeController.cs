using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GitDemoToDoApp.Controllers
{
    // inutilisée
    public class ThemeController : Controller
    {
        // remplacée par un code javascript pour une meilleure expérience utilisateur
        public IActionResult Switch()
        {
            var current = Request.Cookies["Theme"] ?? "light";
            var newTheme = current == "light" ? "dark" : "light";
            Response.Cookies.Append("Theme", newTheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
