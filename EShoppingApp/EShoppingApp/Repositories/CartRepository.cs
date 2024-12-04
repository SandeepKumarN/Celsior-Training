using EShoppingApp.Contexts;
using EShoppingApp.Exceptions;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EShoppingApp.Repositories
{
    public class CartRepository : IRepository<int, Cart>
    {
        private readonly ShoppingContext _context;
        private readonly ILogger<CartRepository> _logger;

        public CartRepository(ShoppingContext shoppingContext, ILogger<CartRepository> logger)
        {
            _context = shoppingContext;
            _logger = logger;
        }

        public async Task<Cart> Add(Cart entity)
        {
            try
            {
                _context.carts.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new CouldNotAddException("Cart");
            }
        }

        public async Task<Cart> Delete(int key)
        {
            var cart = await Get(key);
            if (cart != null)
            {
                _context.carts.Remove(cart);
                await _context.SaveChangesAsync();
                return cart;
            }
            _logger.LogError("Cart not found while trying to delete");
            throw new NotFoundException("Cart for delete");
        }

        public async Task<Cart> Get(int key)
        {
            var cart = _context.carts.FirstOrDefault(c => c.Id == key);
            return cart;
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            var carts = await _context.carts.ToListAsync();
            if (carts.Count == 0)
            {
                throw new CollectionEmptyException("Cart");
            }
            return carts;
        }

        public async Task<Cart> Update(int key, Cart entity)
        {
            var cart = await Get(key);
            if (cart == null)
            {
                throw new NotFoundException("Cart");
            }
            _context.carts.Update(entity);
            await _context.SaveChangesAsync();
            return cart; ;
        }
    }
}
