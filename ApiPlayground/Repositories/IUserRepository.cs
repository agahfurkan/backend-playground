using System.Threading.Tasks;
using ApiPlayground.Entities;

namespace ApiPlayground.Repositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetUserByUsername(string username);
    }
}