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
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(Category category)
        {
            return await _repository.Create(category);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _repository.GetAll(x => x.IsDeleted == false && x.IsActive);
        }
    }
}
