using ArchitectureBlog.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Image> Images { get; set; }

    }
}
