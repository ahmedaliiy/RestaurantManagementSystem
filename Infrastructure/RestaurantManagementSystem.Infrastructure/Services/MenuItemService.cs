using AutoMapper;
using RestaurantManagementSystem.Application.Contracts.Infrastructure;
using RestaurantManagementSystem.Application.Persistence;
using RestaurantManagementSystem.Domain.DTOs;
using RestaurantManagementSystem.Domain.Entities;

namespace RestaurantManagementSystem.Infrastructure.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMapper _mapper;

        public MenuItemService(IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }

        public async Task<MenuItemDto> CreateAsync(MenuItemDto dto)
        {
            var item = _mapper.Map<MenuItem>(dto);

            var result = await _menuItemRepository.AddAsync(item);

            return _mapper.Map<MenuItemDto>(result);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _menuItemRepository.GetByIdAsync(id);
            if (item is not null)
                await _menuItemRepository.DeleteAsync(item);
        }

        public async Task<List<MenuItemDto>> GetAllAsync()
        {
            var items = await _menuItemRepository.GetAllAsync();
            return _mapper.Map<List<MenuItemDto>>(items);
        }

        public async Task<MenuItemDto> GetByIdAsync(int id)
        {
            var resturant = await _menuItemRepository.GetByIdAsync(id);

            return _mapper.Map<MenuItemDto>(resturant);
        }

        public async Task<MenuItemDto> UpdateAsync(MenuItemDto dto)
        {
            var item = await _menuItemRepository.GetByIdAsync(dto.Id);

            if (item is not null)
            {
                item.Name = dto.Name;
                item.Description = dto.Description;
                item.Price = dto.Price;
                item.Category = dto.Category;
                await _menuItemRepository.UpdateAsync(item);
            }

            return _mapper.Map<MenuItemDto>(item);
        }
    }
}
