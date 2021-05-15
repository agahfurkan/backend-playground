using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiPlayground.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
}