using ArchitectureBlog.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Project> Projects { get; set; }
    }
}
