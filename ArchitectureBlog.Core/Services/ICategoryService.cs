using ArchitectureBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.Core.Services
{
    public interface ICategoryService
    {
        Task<int> Create(Category category);
        Task<List<Category>> GetAll();
    }
}
