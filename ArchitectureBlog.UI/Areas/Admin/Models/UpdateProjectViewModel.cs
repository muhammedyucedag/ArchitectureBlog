﻿using ArchitectureBlog.Entities;

namespace ArchitectureBlog.UI.Areas.Admin.Models
{
    public class UpdateProjectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string Location { get; set; }
    }
}
