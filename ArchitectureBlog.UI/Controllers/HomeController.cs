using Microsoft.AspNetCore.Mvc;

namespace ArchitectureBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ArchitectureBlog()
        {
            return View();
        }
        public IActionResult ArchitectureBlogDetail()
        {
            return View();
        }
    }
}
