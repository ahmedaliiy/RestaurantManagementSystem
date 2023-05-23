using RestaurantManagementSystem.Domain.Common;
using RestaurantManagementSystem.Domain.Enums;

namespace RestaurantManagementSystem.Domain.Entities
{
    public class Order : EntityBase
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<MenuItem> Items { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }

        public Order()
        {
            Items = new List<MenuItem>();
        }
    }
}
