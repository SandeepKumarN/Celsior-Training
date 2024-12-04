using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;

namespace EShoppingApp.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO> PlaceOrderAsync(OrderDTO order);
        Task <ICollection<Order>> GetOrdersByUserIdAsync(int customerId);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> UpdateOrderAsync(int orderId, OrderDTO orderDto);
        Task<bool> DeleteOrderAsync(int orderId);
    }
}
