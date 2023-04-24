using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }    
        public DateTime CreationTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
