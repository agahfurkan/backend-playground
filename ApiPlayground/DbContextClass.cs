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

        public DbSet<Category> Category { get; set; }

        public DbSet<OrderStatus> OrderStatus { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<Cart> ActiveCart { get; set; }
    }
}