using System.Collections.Generic;
using System.Threading.Tasks;
using HelloAspNet.Domain.Models;
using HelloAspNet.Domain.Services.Communication;

namespace HelloAspNet.Domain.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ListAsync();
         Task<CategoryResponse> SaveAsync(Category category);
         Task<CategoryResponse> UpdateAsync(int id, Category category);
         Task<Category> FindByIdAsync(int id);
         Task<CategoryResponse> DeleteAsync(int id);
    }
}