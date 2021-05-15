using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayground.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContextClass _dbContextClass;

        protected BaseRepository(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContextClass.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContextClass.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContextClass.Set<T>().AddAsync(entity);
            await _dbContextClass.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await _dbContextClass.Set<T>().FindAsync(id);
            if (entity == null) return entity;

            _dbContextClass.Set<T>().Remove(entity);
            await _dbContextClass.SaveChangesAsync();

            return entity;
        }
    }
}