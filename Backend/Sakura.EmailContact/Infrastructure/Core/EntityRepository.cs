using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sakura.EmailContact.Infrastructure.Core
{

    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        protected DbContext GetContext() => _dbContext;
        public EntityRepository(DbContext dbContex)
        {
            _dbContext = dbContex;
        }


        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await GetOneAsync(predicate);
            if (entity == null)
            {
                return;
            }
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task DeleteRangeAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await AsQueryable().Where(predicate).ToListAsync();
            foreach (var item in entities)
            {
                _dbContext.Set<T>().Remove(item);
            }
        }
    }
}
