using RestaurantManagementSystem.Domain.Entities;

namespace RestaurantManagementSystem.Application.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
