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
    public class ImageService : IImageService
    {
        private IImageRepository _repository;

        public ImageService(IImageRepository repository)
        {
            _repository = repository;
        }
        public Task<int> Create(Image image)
        {
            return _repository.Create(image);
        }
    }
}
