using EShoppingApp.Contexts;
using EShoppingApp.Exceptions;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EShoppingApp.Repositories
{
    public class SupplierRepository : IRepository<int, Supplier>
    {
        private readonly ShoppingContext _context;
        private readonly ILogger<SupplierRepository> _logger;

        public SupplierRepository(ShoppingContext shoppingContext, ILogger<SupplierRepository> logger)
        {
            _context = shoppingContext;
            _logger = logger;
        }

        public async Task<Supplier> Add(Supplier entity)
        {
            try
            {
                _context.suppliers.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new CouldNotAddException("Supplier");
            }
        }

        public async Task<Supplier> Delete(int key)
        {
            var supplier = await Get(key);
            if (supplier != null)
            {
                _context.suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
                return supplier;
            }
            _logger.LogError("Supplier not found while trying to delete");
            throw new NotFoundException("Supplier for delete");
        }

        public async Task<Supplier> Get(int key)
        {
            var supplier = _context.suppliers.FirstOrDefault(c => c.Id == key);
            return supplier;
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            var supplier = await _context.suppliers.ToListAsync();
            if (supplier.Count == 0)
            {
                throw new CollectionEmptyException("Supplier");
            }
            return supplier;
        }

        public async Task<Supplier> Update(int key, Supplier entity)
        {
            var supplier = await Get(key);
            if (supplier == null)
            {
                throw new NotFoundException("Supplier");
            }
            _context.suppliers.Update(entity);
            await _context.SaveChangesAsync();
            return supplier;
        }
    }
}
