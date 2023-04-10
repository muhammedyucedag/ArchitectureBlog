using ArchitectureBlog.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.Entities
{
    public class Image : BaseEntity
    {

        public virtual Project Project { get; set; }
    }
}
