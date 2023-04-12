using Microsoft.AspNetCore.Mvc;

namespace ArchitectureBlog.UI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        [Area("Admin")]
        public IActionResult Index(string username, string password)
        {
            if (username == "moderniz" && password == "1234")
            {
                return RedirectToAction("Index", "Widget");
            }
            return View();
        }
    }
}
