using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sakura.EmailContact.Infrastructure.Core
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();
        Task<List<T>> GetAllAsync();
        void Update(T entity);
        Task<T> GetOneAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task SaveAsync();
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
        Task DeleteRangeAsync(Expression<Func<T, bool>> predicate);
    }
}
