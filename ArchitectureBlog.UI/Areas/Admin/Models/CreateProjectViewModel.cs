using ArchitectureBlog.Entities;
using System.ComponentModel.DataAnnotations;

namespace ArchitectureBlog.UI.Areas.Admin.Models
{
    public class CreateProjectViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }
        public string Location { get; set; }
        public Guid CategoryId { get; set; }
    }
}
