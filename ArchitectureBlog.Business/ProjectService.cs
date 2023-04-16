using ArchitectureBlog.Core.Repositories;
using ArchitectureBlog.Core.Services;
using ArchitectureBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<int> Create()
        {
           return _repository.Create(new Project());
        }
    }
}
