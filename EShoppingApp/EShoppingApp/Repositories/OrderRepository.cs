using EShoppingApp.Contexts;
using EShoppingApp.Exceptions;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EShoppingApp.Repositories
{
    public class OrderRepository : IRepository<int, Order>
    {
        private readonly ShoppingContext _context;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(ShoppingContext context, ILogger<OrderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Order> Add(Order entity)
        {
            try
            {
                _context.orders.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                throw new CouldNotAddException("Order");
            }
        }

        public async Task<Order> Delete(int key)
        {
            var order = await Get(key);
            if (order == null)
            {
                throw new NotFoundException("Order");
            }
            _context.orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> Get(int key)
        {
            var orders =  await _context.orders.FirstOrDefaultAsync(o => o.Id == key);
            if (orders == null)
            {
                throw new NotFoundException("Order");
            }
            return orders;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = await _context.orders.ToListAsync();
            if (orders.Count == 0)
            {
                throw new CollectionEmptyException("Orders");
            }
            return orders;
        }

        public async Task<Order> Update(int key, Order entity)
        {
            var order = await Get(key);
            if (order == null)
            {
                throw new NotFoundException("Order");
            }
            _context.orders.Update(entity);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
