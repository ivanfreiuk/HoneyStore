using HoneyStore.DataAccess.Context;
using HoneyStore.DataAccess.Entities;
using HoneyStore.DataAccess.Interfaces;

namespace HoneyStore.DataAccess.Repositories
{
    public class OrderRepository: BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(StoreDbContext context) : base(context)
        {
        }
    }
}