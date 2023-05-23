using AutoMapper;
using RestaurantManagementSystem.Application.Contracts.Infrastructure;
using RestaurantManagementSystem.Application.Persistence;
using RestaurantManagementSystem.Domain.DTOs;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Enums;
using System.Linq.Expressions;

namespace RestaurantManagementSystem.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateAsync(OrderDto dto)
        {
            // check if all menu items correct
            var order = _mapper.Map<Order>(dto);
            order.Status = Domain.Enums.OrderStatus.Pending;
            order.OrderDate = DateTime.Now;
            order.TotalAmount = dto.Items.Sum(i => i.Price);

            var result = await _orderRepository.AddAsync(order);

            return _mapper.Map<OrderDto>(result);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order is not null)
                await _orderRepository.DeleteAsync(order);
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            List<Expression<Func<Order, object>>> includes = new List<Expression<Func<Order, object>>>
            {
                o => o.Items
            };
            var orders = await _orderRepository.GetAsync(includes: includes);
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            List<Expression<Func<Order, object>>> includes = new List<Expression<Func<Order, object>>>
            {
                o => o.Items
            };
            var orders = await _orderRepository.GetAsync(predicate: o => o.Id == id, includes: includes);

            return _mapper.Map<OrderDto>(orders.FirstOrDefault());
        }

        public async Task<OrderDto> UpdateAsync(OrderDto dto)
        {
            // check if all menu items correct
            List<Expression<Func<Order, object>>> includes = new List<Expression<Func<Order, object>>>
            {
                o => o.Items
            };
            var orders = await _orderRepository.GetAsync(predicate: o => o.Id == dto.Id, includes: includes);

            var order = orders.FirstOrDefault();

            if (order is not null)
            {
                order.Status = Domain.Enums.OrderStatus.Pending;
                order.TotalAmount = dto.Items.Sum(i => i.Price);
                await _orderRepository.UpdateAsync(order);
            }

            return _mapper.Map<OrderDto>(order);
        }

        public async Task ChangeStatus(int id, OrderStatus status)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order is not null)
            {
                order.Status = status;
                await _orderRepository.UpdateAsync(order);
            }
        }
    }
}
