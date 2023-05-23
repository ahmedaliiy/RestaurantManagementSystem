using RestaurantManagementSystem.Domain.Enums;

namespace RestaurantManagementSystem.Domain.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual List<MenuItemDto> Items { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
    }
}
