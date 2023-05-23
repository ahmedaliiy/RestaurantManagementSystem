using RestaurantManagementSystem.Application.Persistence;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Infrastructure.Persistence;

namespace RestaurantManagementSystem.Infrastructure.Repositories
{
    public class InventoryItemRepository : RepositoryBase<InventoryItem>, IInventoryItemRepository
    {
        private readonly ResturantDbContext _dbContext;

        public InventoryItemRepository(ResturantDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
