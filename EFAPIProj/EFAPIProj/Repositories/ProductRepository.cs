using EFAPIProj.Models;
using EFAPIProj.Interfaces;
using Microsoft.EntityFrameworkCore;
using EFAPIProj.Properties.Context;

namespace EFAPIProj.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly ShoppingContext _context;

        public ProductRepository(ShoppingContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.Include(p => p.ProductImages).ToListAsync();
        }

        public async Task<Product> Update(int id, Product entity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Name = entity.Name;
            product.Description = entity.Description;
            product.Quantity = entity.Quantity;
            product.Price = entity.Price;
            product.BasicImage = entity.BasicImage;

            await _context.SaveChangesAsync();
            return product;
        }

        public Task<Customer> Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
