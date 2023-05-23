using RestaurantManagementSystem.Domain.Common;
using RestaurantManagementSystem.Domain.Enums;

namespace RestaurantManagementSystem.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public Roles Role { get; set; }
    }
}
