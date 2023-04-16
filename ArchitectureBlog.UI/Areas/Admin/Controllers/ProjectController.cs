using ArchitectureBlog.Core.Services;
using ArchitectureBlog.Entities;
using ArchitectureBlog.UI.Areas.Admin.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArchitectureBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private ICategoryService _categoryService;
        private IProjectService _projectService;

        public ProjectController(ICategoryService categoryService, IProjectService projectService)
        {
            _categoryService = categoryService;
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            var categories = await _categoryService.GetAll();
            foreach (var category in categories)
            {
                selectListItems.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            ViewBag.Categories = selectListItems;

            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateProjectViewModel model)
        {
            return View();
        }
    }
}
