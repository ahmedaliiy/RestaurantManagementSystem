using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Contracts.Infrastructure;
using RestaurantManagementSystem.Domain.DTOs;
using RestaurantManagementSystem.Infrastructure.Services;

namespace RestaurantManagementSystem.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }


        [HttpGet]
        public async Task<ActionResult<List<MenuItemDto>>> GetAllItems()
        {
            var items = await _menuItemService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDto>> GetItemById(int id)
        {
            var item = await _menuItemService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem([FromBody] MenuItemDto dto)
        {
            var result = await _menuItemService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetItemById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id, [FromBody] MenuItemDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var result = await _menuItemService.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            await _menuItemService.DeleteAsync(id);
            return Ok();
        }
    }
}
