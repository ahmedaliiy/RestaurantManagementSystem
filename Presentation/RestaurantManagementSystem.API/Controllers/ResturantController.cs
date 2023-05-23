using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Contracts.Infrastructure;
using RestaurantManagementSystem.Domain.DTOs;

namespace RestaurantManagementSystem.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly IResturantService _resturantService;

        public ResturantController(IResturantService resturantService)
        {
            _resturantService = resturantService;
        }


        [HttpGet]
        public async Task<ActionResult<List<RestaurantDto>>> GetAllResturants()
        {
            var restaurants = await _resturantService.GetAllAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto>> GetResturantById(int id)
        {
            var restaurant = await _resturantService.GetByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult> CreateResturant([FromBody] RestaurantDto dto)
        {
            var result = await _resturantService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetResturantById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateResturant(int id, [FromBody] RestaurantDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var result = await _resturantService.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteResturant(int id)
        {
            await _resturantService.DeleteAsync(id);
            return Ok();
        }
    }
}
