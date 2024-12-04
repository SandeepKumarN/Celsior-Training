using EShoppingApp.Contexts;
using EShoppingApp.Exceptions;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EShoppingApp.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly ShoppingContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ShoppingContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Product> Add(Product entity)
        {
            try
            {
                _context.products.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new CouldNotAddException("Product");
            }
        }

        public async Task<Product> Delete(int key)
        {
            var product = await Get(key);
            if (product == null)
            {
                throw new NotFoundException("Product");
            }
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Get(int key)
        {
            var product = await _context.products.FirstOrDefaultAsync(p => p.Id == key);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.products.ToListAsync();
            if (products.Count == 0)
            {
                throw new CollectionEmptyException("Products");
            }
            return products;
        }

        public async Task<Product> Update(int key, Product entity)
        {
            var product = await Get(key);
            if (product == null)
            {
                throw new NotFoundException("Product");
            }
            _context.products.Update(entity);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
