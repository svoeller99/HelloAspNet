using System.Collections.Generic;
using System.Threading.Tasks;
using HelloAspNet.Domain.Models;
using HelloAspNet.Domain.Services.Communication;

namespace HelloAspNet.Domain.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ListAsync();
         Task<SaveCategoryResponse> SaveAsync(Category category);
    }
}