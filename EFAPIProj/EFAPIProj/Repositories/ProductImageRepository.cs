using EFAPIProj.Models;
using EFAPIProj.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFAPIProj.Properties.Context;

namespace EFAPIProj.Repositories
{
    public class ProductImageRepository : IRepository<int, ProductImage>
    {
        private readonly ShoppingContext _context;

        public ProductImageRepository(ShoppingContext context)
        {
            _context = context;
        }

        public async Task<ProductImage> Add(ProductImage entity)
        {
            _context.ProductImages.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ProductImage> Delete(int id)
        {
            var productImage = await _context.ProductImages.FindAsync(id);
            if (productImage == null) return null;

            _context.ProductImages.Remove(productImage);
            await _context.SaveChangesAsync();
            return productImage;
        }

        public async Task<ProductImage> Get(int id)
        {
            return await _context.ProductImages.FindAsync(id);
        }

        public async Task<IEnumerable<ProductImage>> GetAll()
        {
            return await _context.ProductImages.ToListAsync();
        }

        public async Task<ProductImage> Update(int id, ProductImage entity)
        {
            var productImage = await _context.ProductImages.FindAsync(id);
            if (productImage == null) return null;

            productImage.ImageUrl = entity.ImageUrl;

            await _context.SaveChangesAsync();
            return productImage;
        }
    }
}
