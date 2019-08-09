using System.Collections.Generic;
using System.Threading.Tasks;
using HelloAspNet.Domain.Models;

namespace HelloAspNet.Domain.Repositories
{
    public interface ICategoryRepository
    {
         Task<IEnumerable<Category>> ListAsync();
    }
}