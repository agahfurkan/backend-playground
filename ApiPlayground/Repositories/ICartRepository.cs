using System.Collections.Generic;
using System.Threading.Tasks;
using ApiPlayground.Entities;

namespace ApiPlayground.Repositories
{
    public interface ICartRepository : IBaseRepository<CartEntity>
    {
        Task<bool> RemoveProductFromCartAsync(int productId, long userId);
        Task<List<CartEntity>> GetUserCartAsync(long userId);
    }
}