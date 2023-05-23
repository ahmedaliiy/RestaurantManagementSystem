using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagementSystem.Application.Contracts.Infrastructure;
using RestaurantManagementSystem.Application.Persistence;
using RestaurantManagementSystem.Infrastructure.Persistence;
using RestaurantManagementSystem.Infrastructure.Repositories;
using RestaurantManagementSystem.Infrastructure.Services;

namespace RestaurantManagementSystem.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ResturantDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ResturantManagementSystem")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<IResturantRepository, ResturantRepository>();
            services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            
            services.AddScoped<IResturantService, ResturantService>();
            services.AddScoped<IInventoryItemService, InventoryItemService>();
            services.AddScoped<IMenuItemService, MenuItemService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
