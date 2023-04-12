using Microsoft.AspNetCore.Mvc;

namespace ArchitectureBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
