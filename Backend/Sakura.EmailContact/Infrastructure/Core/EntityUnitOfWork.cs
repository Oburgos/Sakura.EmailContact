using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Sakura.EmailContact.Infrastructure.Core
{
    public class EntityUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext context;
        public EntityUnitOfWork(TContext context)
        {
            this.context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EntityRepository<T>(context);
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                if (Transaction == null)
                {
                    await BeginTransactionAsync();
                    await context.SaveChangesAsync();
                    Commit();
                }

                await context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                RollBack();
                throw ex;
            }
        }

        private IDbContextTransaction Transaction { get; set; }
        public async Task BeginTransactionAsync()
        {
            Transaction = await context.Database.BeginTransactionAsync();
        }

        public void Commit()
        {
            if (Transaction == null)
            {
                return;
            }
            Transaction.Commit();
            Transaction = null;
        }

        public void RollBack()
        {
            if (Transaction == null)
            {
                return;
            }
            Transaction.Rollback();
            Transaction = null;
        }
    }
}
