using AutoMapper;
using RestaurantManagementSystem.Application.Contracts.Infrastructure;
using RestaurantManagementSystem.Application.Persistence;
using RestaurantManagementSystem.Domain.DTOs;
using RestaurantManagementSystem.Domain.Entities;

namespace RestaurantManagementSystem.Infrastructure.Services
{
    public class InventoryItemService : IInventoryItemService
    {
        private readonly IInventoryItemRepository _inventoryItemRepository;
        private readonly IMapper _mapper;

        public InventoryItemService(IInventoryItemRepository inventoryItemRepository, IMapper mapper)
        {
            _inventoryItemRepository = inventoryItemRepository;
            _mapper = mapper;
        }

        public async Task<InventoryItemDto> CreateAsync(InventoryItemDto dto)
        {
            var item = _mapper.Map<InventoryItem>(dto);

            var result = await _inventoryItemRepository.AddAsync(item);

            return _mapper.Map<InventoryItemDto>(result);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _inventoryItemRepository.GetByIdAsync(id);
            if (item is not null)
                await _inventoryItemRepository.DeleteAsync(item);
        }

        public async Task<List<InventoryItemDto>> GetAllAsync()
        {
            var items = await _inventoryItemRepository.GetAllAsync();
            return _mapper.Map<List<InventoryItemDto>>(items);
        }

        public async Task<InventoryItemDto> GetByIdAsync(int id)
        {
            var resturant = await _inventoryItemRepository.GetByIdAsync(id);

            return _mapper.Map<InventoryItemDto>(resturant);
        }

        public async Task<InventoryItemDto> UpdateAsync(InventoryItemDto dto)
        {
            var item = await _inventoryItemRepository.GetByIdAsync(dto.Id);

            if (item is not null)
            {
                item.Name = dto.Name;
                item.Quantity = dto.Quantity;
                await _inventoryItemRepository.UpdateAsync(item);
            }

            return _mapper.Map<InventoryItemDto>(item);
        }
    }
}
