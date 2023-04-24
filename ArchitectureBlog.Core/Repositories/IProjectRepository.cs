using ArchitectureBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.Core.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<Project>> GetAllProjectIncludeCategory(Expression<Func<Project, bool>> expression);
        Project GetBlogById(Guid id);
    }
}
