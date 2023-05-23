using RestaurantManagementSystem.Application.Persistence;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Infrastructure.Persistence;

namespace RestaurantManagementSystem.Infrastructure.Repositories
{
    public class ResturantRepository : RepositoryBase<Restaurant>, IResturantRepository
    {
        private readonly ResturantDbContext _dbContext;

        public ResturantRepository(ResturantDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
