using RestaurantManagementSystem.Application.Persistence;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Infrastructure.Persistence;

namespace RestaurantManagementSystem.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly ResturantDbContext _dbContext;

        public OrderRepository(ResturantDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
