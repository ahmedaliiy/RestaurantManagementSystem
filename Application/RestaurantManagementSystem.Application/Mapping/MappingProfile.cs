using AutoMapper;
using RestaurantManagementSystem.Domain.DTOs;
using RestaurantManagementSystem.Domain.Entities;

namespace RestaurantManagementSystem.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
        }
    }
}
