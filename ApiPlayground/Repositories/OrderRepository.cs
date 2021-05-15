using ApiPlayground.Entities;

namespace ApiPlayground.Repositories
{
    public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(DbContextClass dbContextClass) : base(dbContextClass)
        {
        }
    }
}