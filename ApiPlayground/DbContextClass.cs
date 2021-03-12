using ApiPlayground.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayground
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}