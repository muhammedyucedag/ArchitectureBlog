using ArchitectureBlog.Core.Services;
using ArchitectureBlog.Entities;
using ArchitectureBlog.UI.Areas.Admin.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryViewModel model)
        {
            Category category = new Category
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                CreationTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            await _categoryService.Create(category);

            return View();
        }
    }
}
