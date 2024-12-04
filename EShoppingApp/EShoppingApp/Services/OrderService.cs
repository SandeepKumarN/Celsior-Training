using AutoMapper;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Repositories;

namespace EShoppingApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<int, Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<int, Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDTO> PlaceOrderAsync(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var addedOrder = await _orderRepository.Add(order);
            return _mapper.Map<OrderDTO>(addedOrder);
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.Get(orderId);
            return order;
        }

        public async Task<Order> UpdateOrderAsync(int orderId, OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var updatedOrder = await _orderRepository.Update(orderId, order);
            return updatedOrder;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            await _orderRepository.Delete(orderId);
            return true;
        }

        public async Task<ICollection<Order>> GetOrdersByUserIdAsync(int customerId)
        {
            var orders = await _orderRepository.GetAll();
            var userOrders = orders.Where(o => o.CustomerId == customerId).ToList();
            return userOrders;
        }
    }
}
