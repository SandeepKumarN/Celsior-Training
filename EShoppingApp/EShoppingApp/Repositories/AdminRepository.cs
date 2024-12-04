using EShoppingApp.Contexts;
using EShoppingApp.Exceptions;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EShoppingApp.Repositories
{
    public class AdminRepository : IRepository<int, Admin>
    {
        private readonly ShoppingContext _context;
        private readonly ILogger<AdminRepository> _logger;

        public AdminRepository(ShoppingContext shoppingContext, ILogger<AdminRepository> logger)
        {
            _context = shoppingContext;
            _logger = logger;
        }

        public async Task<Admin> Add(Admin entity)
        {
            try
            {
                _context.admins.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new CouldNotAddException("Admin");
            }
        }

        public async Task<Admin> Delete(int key)
        {
            var admin = await Get(key);
            if (admin != null)
            {
                _context.admins.Remove(admin);
                await _context.SaveChangesAsync();
                return admin;
            }
            _logger.LogError("Customer not found while trying to delete");
            throw new NotFoundException("Customer for delete");
        }

        public async Task<Admin> Get(int key)
        {
            var admin = _context.admins.FirstOrDefault(c => c.Id == key);
            return admin;
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            var admin = await _context.admins.ToListAsync();
            if (admin.Count == 0)
            {
                throw new CollectionEmptyException("Admin");
            }
            return admin;
        }

        public async Task<Admin> Update(int key, Admin entity)
        {
            var admin = await Get(key);
            if (admin == null)
            {
                throw new NotFoundException("Admin");
            }
            admin.Name = entity.Name;
            admin.Email = entity.Email;
            admin.Phone = entity.Phone;
            await _context.SaveChangesAsync();
            return admin;
        }
    }
}
