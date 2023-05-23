using AutoMapper;
using RestaurantManagementSystem.Application.Contracts.Infrastructure;
using RestaurantManagementSystem.Application.Persistence;
using RestaurantManagementSystem.Domain.DTOs;
using RestaurantManagementSystem.Domain.Entities;

namespace RestaurantManagementSystem.Infrastructure.Services
{
    public class ResturantService : IResturantService
    {
        private readonly IResturantRepository _resturantRepository;
        private readonly IMapper _mapper;

        public ResturantService(IResturantRepository resturantRepository, IMapper mapper)
        {
            _resturantRepository = resturantRepository;
            _mapper = mapper;
        }

        public async Task<RestaurantDto> CreateAsync(RestaurantDto dto)
        {
            var resturant = _mapper.Map<Restaurant>(dto);

            var result = await _resturantRepository.AddAsync(resturant);

            return _mapper.Map<RestaurantDto>(result);
        }

        public async Task DeleteAsync(int id)
        {
            var resturant = await _resturantRepository.GetByIdAsync(id);
            if (resturant is not null)
                await _resturantRepository.DeleteAsync(resturant);
        }

        public async Task<List<RestaurantDto>> GetAllAsync()
        {
            var resturants = await _resturantRepository.GetAllAsync();
            return _mapper.Map<List<RestaurantDto>>(resturants);
        }

        public async Task<RestaurantDto> GetByIdAsync(int id)
        {
            var resturant = await _resturantRepository.GetByIdAsync(id);

            return _mapper.Map<RestaurantDto>(resturant);
        }

        public async Task<RestaurantDto> UpdateAsync(RestaurantDto dto)
        {
            var resturant = await _resturantRepository.GetByIdAsync(dto.Id);

            if (resturant is not null)
            {
                resturant.Name = dto.Name;
                resturant.Address = dto.Address;
                resturant.ContactNumber = dto.ContactNumber;
                await _resturantRepository.UpdateAsync(resturant);
            }

            return _mapper.Map<RestaurantDto>(resturant);
        }
    }
}
