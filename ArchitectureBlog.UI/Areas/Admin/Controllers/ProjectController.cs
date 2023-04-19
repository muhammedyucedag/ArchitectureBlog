using ArchitectureBlog.Business;
using ArchitectureBlog.Core.Repositories;
using ArchitectureBlog.Core.Services;
using ArchitectureBlog.DataAccess.Repositories;
using ArchitectureBlog.Entities;
using ArchitectureBlog.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;

namespace ArchitectureBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private ICategoryService _categoryService;
        private IProjectService _projectService;
        private IImageService _imageService;    

        IProjectRepository ProjectRepository { get; set; }

        public ProjectController(ICategoryService categoryService, IProjectService projectService, IImageService imageService)
        {
            _categoryService = categoryService;
            _projectService = projectService;
            _imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _projectService.GetAll(x => x.IsActive /*&& x.IsDeleted == false*/);

            IndexProjectViewModel model = new IndexProjectViewModel
            {
                Projects = projects
            };

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            var categories = await _categoryService.GetAll(x => x.IsActive && x.IsDeleted == false);
            foreach (var category in categories)
            {
                selectListItems.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            ViewBag.Categories = selectListItems;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProjectViewModel model, IList<IFormFile> formColection)
        {
            try
            {
                Project project = new Project
                {
                    CreationTime = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    Name = model.Title,
                    Description = model.Description,
                    Id = Guid.NewGuid(),
                    CategoryId = model.CategoryId
                };

                var isSuccess = await _projectService.Create(project) > 0;

                if (formColection != null && formColection.Count() > 0 && isSuccess)
                {
                    foreach (var formFile in formColection)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", formFile.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }

                        Image image = new Image
                        {
                            CreationTime = DateTime.Now,
                            IsActive = true,
                            IsDeleted = false,
                            Url = "/Images/" + formFile.FileName,
                            ProjectId = project.Id
                        };

                        await _imageService.Create(image);
                    }
                }
            }
            catch (Exception error)
            {

                return Content(error.ToString());
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Passive(Guid id)
        {
            var project = await _projectService.Get(x => x.Id == id);
            project.IsDeleted = true;
            await _projectService.Update(project);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Active(Guid id)
        {
            var project = await _projectService.Get(x => x.Id == id);
            project.IsDeleted = false;
            await _projectService.Update(project);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var project = await _projectService.Get(x => x.Id == id);
            //List<SelectListItem> values = (from x in _categoryService.GetAll() select new SelectListItem
            //{
            //    Text= x.Name,
            //    Value=x.Id.ToString()
            //}).ToList();

            UpdateProjectViewModel model = new UpdateProjectViewModel
            {
                Name = project.Name,
                Id = project.Id,
                Description = project.Description
            };

            return View(model);
        }
        
    }
}
