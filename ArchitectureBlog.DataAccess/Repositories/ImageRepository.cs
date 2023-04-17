using ArchitectureBlog.Core.Repositories;
using ArchitectureBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.DataAccess.Repositories
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
