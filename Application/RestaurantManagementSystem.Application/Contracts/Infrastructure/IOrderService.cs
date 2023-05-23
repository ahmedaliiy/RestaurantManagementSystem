using RestaurantManagementSystem.Domain.DTOs;
using RestaurantManagementSystem.Domain.Enums;

namespace RestaurantManagementSystem.Application.Contracts.Infrastructure
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int id);
        Task<OrderDto> CreateAsync(OrderDto dto);
        Task<OrderDto> UpdateAsync(OrderDto dto);
        Task DeleteAsync(int id);
        Task ChangeStatus(int id, OrderStatus status);
    }
}
