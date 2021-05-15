using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPlayground.Entities;
using ApiPlayground.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayground.Repositories
{
    public class CartRepository : BaseRepository<CartEntity>, ICartRepository
    {
        private readonly DbContextClass _dbContextClass;

        public CartRepository(DbContextClass dbContextClass) : base(dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        public async Task<List<CartEntity>> GetUserCartAsync(long userId)
        {
            return await _dbContextClass.Cart.Where(cart => cart.UserId == userId).ToListAsync();

        }

        public async Task<bool> RemoveProductFromCartAsync(int productId, long userId)
        {
            var tempProduct =
                await _dbContextClass.Cart.FirstOrDefaultAsync(p => p.ProductId == productId && p.UserId == userId);
            if (tempProduct == null)
                return false;
            _dbContextClass.Cart.Remove(tempProduct);
            await _dbContextClass.SaveChangesAsync();
            return true;
        }
    }
}