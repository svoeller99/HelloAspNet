using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // needed for ToListAsync
using HelloAspNet.Domain.Models;
using HelloAspNet.Domain.Repositories;
using HelloAspNet.Persistence.Contexts;

namespace HelloAspNet.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> ListAsync() 
        {
            return await _context.Categories.ToListAsync(); // supposed to be an extension method called ToListAsync
        }
    }
}