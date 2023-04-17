using ArchitectureBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.Core.Services
{
    public interface ICategoryService
    {
        Task<int> Create(Category category);
        Task<List<Category>> GetAll(Expression<Func<Category, bool>> expression);
        Task<Category> Get(Expression<Func<Category, bool>> expression);
        Task<int> Update(Category category);
    }
}
