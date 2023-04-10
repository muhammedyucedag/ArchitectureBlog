using ArchitectureBlog.Core.Repositories;
using ArchitectureBlog.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _dbContext;

        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return await Save();
        }

        public async Task<T> Find(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<int> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return await Save();
        }

        private async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
