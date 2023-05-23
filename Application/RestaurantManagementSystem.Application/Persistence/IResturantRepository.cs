using RestaurantManagementSystem.Domain.Entities;

namespace RestaurantManagementSystem.Application.Persistence
{
    public interface IResturantRepository : IAsyncRepository<Restaurant>
    {
    }
}
