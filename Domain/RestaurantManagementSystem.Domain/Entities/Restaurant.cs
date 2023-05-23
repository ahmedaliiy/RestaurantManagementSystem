using RestaurantManagementSystem.Domain.Common;

namespace RestaurantManagementSystem.Domain.Entities
{
    public class Restaurant : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
    }
}
