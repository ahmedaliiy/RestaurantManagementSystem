using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Domain.Common;
using RestaurantManagementSystem.Domain.Entities;

namespace RestaurantManagementSystem.Infrastructure.Persistence
{
    public class ResturantDbContext : DbContext
    {
        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<EntityBase>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entity.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
