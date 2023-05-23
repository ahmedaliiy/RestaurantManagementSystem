using RestaurantManagementSystem.Application.Persistence;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Infrastructure.Persistence;

namespace RestaurantManagementSystem.Infrastructure.Repositories
{
    public class MenuItemRepository : RepositoryBase<MenuItem>, IMenuItemRepository
    {
        private readonly ResturantDbContext _dbContext;

        public MenuItemRepository(ResturantDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
