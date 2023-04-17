using ArchitectureBlog.Core.Services;
using ArchitectureBlog.DataAccess;
using ArchitectureBlog.Entities;
using ArchitectureBlog.UI.Areas.Admin.Models;
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

        public async Task<IActionResult> Index()
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = await _categoryService.GetAll(x => x.IsActive)
            };

            return View(model);
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

        [HttpPost]
        public async Task<IActionResult> Passive(Guid id)
        {
            var category = await _categoryService.Get(x => x.Id == id);
            category.IsDeleted = true;
            await _categoryService.Update(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Active(Guid id)
        {
            var category = await _categoryService.Get(x => x.Id == id);
            category.IsDeleted = false;
            await _categoryService.Update(category);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var category = await _categoryService.Get(x => x.Id == id);

            UpdateCategoryViewModel model = new UpdateCategoryViewModel
            {
                Name = category.Name,
                Id = category.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryViewModel model)
        {
            var category = await _categoryService.Get(x => x.Id == model.Id);
            category.Name = model.Name;
            await _categoryService.Update(category);

            return RedirectToAction("Index");
        }
    }
}
