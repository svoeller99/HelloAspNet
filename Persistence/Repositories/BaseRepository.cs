using HelloAspNet.Persistence.Contexts;

namespace HelloAspNet.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context) {
            _context = context;
        }
    }
}