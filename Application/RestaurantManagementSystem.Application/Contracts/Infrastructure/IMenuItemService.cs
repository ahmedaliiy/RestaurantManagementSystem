using RestaurantManagementSystem.Domain.DTOs;

namespace RestaurantManagementSystem.Application.Contracts.Infrastructure
{
    public interface IMenuItemService
    {
        Task<List<MenuItemDto>> GetAllAsync();
        Task<MenuItemDto> GetByIdAsync(int id);
        Task<MenuItemDto> CreateAsync(MenuItemDto dto);
        Task<MenuItemDto> UpdateAsync(MenuItemDto dto);
        Task DeleteAsync(int id);
    }
}
