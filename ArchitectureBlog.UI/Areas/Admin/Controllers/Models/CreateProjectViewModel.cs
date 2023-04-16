using ArchitectureBlog.Entities;

namespace ArchitectureBlog.UI.Areas.Admin.Controllers.Models
{
    public class CreateProjectViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
