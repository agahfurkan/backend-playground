using System.Threading.Tasks;
using ApiPlayground.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayground.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        private readonly DbContextClass _dbContextClass;

        public CategoryRepository(DbContextClass dbContextClass) : base(dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        public async Task<CategoryEntity> GetCategoryByName(string categoryName)
        {
            return await _dbContextClass.Category.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
        }
    }
}