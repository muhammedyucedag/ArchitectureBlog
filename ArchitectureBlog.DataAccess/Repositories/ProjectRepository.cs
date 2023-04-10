using ArchitectureBlog.Core.Repositories;
using ArchitectureBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.DataAccess.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
