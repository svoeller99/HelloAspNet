using System.Threading.Tasks;

namespace HelloAspNet.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}