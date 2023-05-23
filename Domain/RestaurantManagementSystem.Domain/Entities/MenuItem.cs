using RestaurantManagementSystem.Domain.Common;

namespace RestaurantManagementSystem.Domain.Entities
{
    public class MenuItem : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
