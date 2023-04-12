using Microsoft.AspNetCore.Mvc;

namespace ArchitectureBlog.UI.Areas.Admin.Controllers
{
    public class ProjectController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
