using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiPlayground.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Delete(int id);
    }
}