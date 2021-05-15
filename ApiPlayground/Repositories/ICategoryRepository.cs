using System.Threading.Tasks;
using ApiPlayground.Entities;

namespace ApiPlayground.Repositories
{
    public interface ICategoryRepository:IBaseRepository<CategoryEntity>
    {
        Task<CategoryEntity> GetCategoryByName(string categoryName);
    }
}