using System.Collections.Generic;
using System.Threading.Tasks;
using HelloAspNet.Domain.Models;

namespace HelloAspNet.Domain.Repositories
{
    public interface ICategoryRepository
    {
         Task<IEnumerable<Category>> ListAsync();
         Task AddAsync(Category category);
         Task<Category> FindByIdAsync(int id);
         void Update(Category category);
    }
}