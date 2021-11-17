using System.Collections.Generic;
using System.Threading.Tasks;
using ApiPlayground.Entities;

namespace ApiPlayground.Repositories
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {
        Task<List<ProductEntity>> GetProductsByCategoryId(int categoryId, int pageIndex, int pageLength);
    }
}