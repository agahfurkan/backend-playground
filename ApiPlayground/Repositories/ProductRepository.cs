using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPlayground.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayground.Repositories
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        private readonly DbContextClass _dbContextClass;

        public ProductRepository(DbContextClass dbContextClass) : base(dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        public async Task<List<ProductEntity>> GetProductsByCategoryId(int categoryId)
        {
            return await _dbContextClass.Product.Where(product => product.CategoryId == categoryId).ToListAsync();
        }
    }
}