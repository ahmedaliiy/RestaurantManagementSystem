using RestaurantManagementSystem.Domain.Common;

namespace RestaurantManagementSystem.Domain.Entities
{
    public class InventoryItem : EntityBase
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
