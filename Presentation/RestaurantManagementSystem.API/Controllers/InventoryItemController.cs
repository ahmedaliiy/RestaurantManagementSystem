using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Contracts.Infrastructure;
using RestaurantManagementSystem.Domain.DTOs;
using RestaurantManagementSystem.Infrastructure.Services;

namespace RestaurantManagementSystem.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly IInventoryItemService _inventoryItemService;

        public InventoryItemController(IInventoryItemService inventoryItemService)
        {
            _inventoryItemService = inventoryItemService;
        }


        [HttpGet]
        public async Task<ActionResult<List<InventoryItemDto>>> GetAllItemss()
        {
            var items = await _inventoryItemService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItemDto>> GetItemById(int id)
        {
            var item = await _inventoryItemService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem([FromBody] InventoryItemDto dto)
        {
            var result = await _inventoryItemService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetItemById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id, [FromBody] InventoryItemDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var result = await _inventoryItemService.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            await _inventoryItemService.DeleteAsync(id);
            return Ok();
        }
    }
}
