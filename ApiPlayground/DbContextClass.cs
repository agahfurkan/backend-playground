using ApiPlayground.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayground
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> User { get; set; }

        public DbSet<ProductEntity> Product { get; set; }

        public DbSet<CategoryEntity> Category { get; set; }

        public DbSet<OrderStatusEntity> OrderStatus { get; set; }

        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<CartEntity> Cart { get; set; }
    }
}