using ArchitectureBlog.Core.Repositories;
using ArchitectureBlog.Core.Services;
using ArchitectureBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.Business
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(Project project)
        {
           return await _repository.Create(project);
        }

        public async Task<Project> Get(Expression<Func<Project, bool>> expression)
        {
            return await _repository.Find(expression);
        }

        public async Task<List<Project>> GetAll(Expression<Func<Project, bool>> expression)
        {
            return await _repository.GetAllProjectIncludeCategory(expression);
        }

        public async Task<int> Update(Project project)
        {
            return await _repository.Update(project);
        }
       
    }
}
