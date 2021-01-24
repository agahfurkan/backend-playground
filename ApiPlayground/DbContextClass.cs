using ApiPlayground.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayground
{
    public class DbContextClass: DbContext   
    {
        public DbContextClass (DbContextOptions<DbContextClass> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}