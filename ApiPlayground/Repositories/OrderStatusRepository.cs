using ApiPlayground.Entities;

namespace ApiPlayground.Repositories
{
    public class OrderStatusRepository:BaseRepository<OrderStatusEntity>,IOrderStatusRepository
    {
        public OrderStatusRepository(DbContextClass dbContextClass) : base(dbContextClass)
        {
        }
    }
}