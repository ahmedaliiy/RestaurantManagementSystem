using RestaurantManagementSystem.Domain.DTOs;

namespace RestaurantManagementSystem.Application.Contracts.Infrastructure
{
    public interface IInventoryItemService
    {
        Task<List<InventoryItemDto>> GetAllAsync();
        Task<InventoryItemDto> GetByIdAsync(int id);
        Task<InventoryItemDto> CreateAsync(InventoryItemDto dto);
        Task<InventoryItemDto> UpdateAsync(InventoryItemDto dto);
        Task DeleteAsync(int id);
    }
}
