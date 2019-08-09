using System.Collections.Generic;
using System.Threading.Tasks;
using HelloAspNet.Domain.Models;

namespace HelloAspNet.Domain.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ListAsync();
    }
}