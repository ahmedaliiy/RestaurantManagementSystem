using RestaurantManagementSystem.Domain.Entities;

namespace RestaurantManagementSystem.Application.Persistence
{
    public interface IMenuItemRepository : IAsyncRepository<MenuItem>
    {
    }
}
