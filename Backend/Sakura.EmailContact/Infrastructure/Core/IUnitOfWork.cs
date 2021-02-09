using System.Threading.Tasks;

namespace Sakura.EmailContact.Infrastructure.Core
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task SaveChangesAsync();
        Task BeginTransactionAsync();
        void RollBack();
        void Commit();
    }
}
