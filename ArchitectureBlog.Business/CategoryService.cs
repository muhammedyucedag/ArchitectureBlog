using ArchitectureBlog.Core.Repositories;
using ArchitectureBlog.Core.Services;
using ArchitectureBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<List<Category>> GetAll(Expression<Func<Category, bool>> expression)
        {
            return await _repository.GetAll(expression);
        }

        public async Task<Category> Get(Expression<Func<Category, bool>> expression)
        {
            return await _repository.Find(expression);
        }

        public async Task<int> Update(Category category)
        {
            return await _repository.Update(category);
        }
    }
}
