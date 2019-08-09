using System.Collections.Generic;
using System.Threading.Tasks;
using HelloAspNet.Domain.Models;
using HelloAspNet.Domain.Repositories;

namespace HelloAspNet.Domain.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }
    }
}