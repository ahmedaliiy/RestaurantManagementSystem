using RestaurantManagementSystem.Domain.Entities;

namespace RestaurantManagementSystem.Application.Persistence
{
    public interface IInventoryItemRepository : IAsyncRepository<InventoryItem>
    {
    }
}
