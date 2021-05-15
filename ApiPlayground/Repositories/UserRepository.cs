using System;
using System.Threading.Tasks;
using ApiPlayground.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayground.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly DbContextClass _dbContextClass;
        public UserRepository(DbContextClass dbContextClass) : base(dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        public async Task<UserEntity> GetUserByUsernameAsync(string username)
        {
            return await _dbContextClass.User.FirstOrDefaultAsync(u => u.Username == username);
        }
        
    }
}