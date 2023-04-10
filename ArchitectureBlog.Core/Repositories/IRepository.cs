using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);
        Task<T> Find(Expression<Func<T, bool>> expression);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
    }
}
