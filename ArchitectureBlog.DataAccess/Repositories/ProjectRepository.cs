using ArchitectureBlog.Core.Repositories;
using ArchitectureBlog.Entities;
using Microsoft.EntityFrameworkCore;
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
        private readonly DataContext _dbContext;

        public ProjectRepository(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Project>> GetAllProjectIncludeCategory(Expression<Func<Project, bool>> expression)
        {
            return await _dbContext.Projects.Include("Category").Include("Images").Where(expression).ToListAsync();
        }
    }
}
