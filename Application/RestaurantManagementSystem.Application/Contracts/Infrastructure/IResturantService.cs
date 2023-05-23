using RestaurantManagementSystem.Domain.DTOs;

namespace RestaurantManagementSystem.Application.Contracts.Infrastructure
{
    public interface IResturantService
    {
        Task<List<RestaurantDto>> GetAllAsync();
        Task<RestaurantDto> GetByIdAsync(int id);
        Task<RestaurantDto> CreateAsync(RestaurantDto dto);
        Task<RestaurantDto> UpdateAsync(RestaurantDto dto);
        Task DeleteAsync(int id);
    }
}
