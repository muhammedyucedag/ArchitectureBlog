using ArchitectureBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.Core.Services
{
    public interface IProjectService
    {
        Task<int> Create(Project project);
        Task<List<Project>> GetAll(Expression<Func<Project, bool>> expression);
        Task<Project> Get(Expression<Func<Project, bool>> expression);
        Task<int> Update(Project project);
    }
}
