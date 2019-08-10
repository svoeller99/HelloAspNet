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

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}