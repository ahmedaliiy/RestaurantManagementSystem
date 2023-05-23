using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Contracts.Infrastructure;
using RestaurantManagementSystem.Domain.DTOs;
using RestaurantManagementSystem.Domain.Enums;

namespace RestaurantManagementSystem.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderDto dto)
        {
            var result = await _orderService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetOrderById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, [FromBody] OrderDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var result = await _orderService.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("ChangeStatus/{id}")]
        public async Task<ActionResult> UpdateOrder(int id, [FromBody] OrderStatus status)
        {
            await _orderService.ChangeStatus(id, status);
            return Ok();
        }
    }
}
