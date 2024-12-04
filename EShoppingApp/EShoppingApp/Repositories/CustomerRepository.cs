using EShoppingApp.Contexts;
using EShoppingApp.Exceptions;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EShoppingApp.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private readonly ShoppingContext _context;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(ShoppingContext shoppingContext, ILogger<CustomerRepository> logger)
        {
            _context = shoppingContext;
            _logger = logger;
        }

        public async Task<Customer> Add(Customer entity)
        {
            try
            {
                _context.customers.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new CouldNotAddException("Customer");
            }
        }

        public async Task<Customer> Delete(int key)
        {
            var customer = await Get(key);
            if (customer != null)
            {
                _context.customers.Remove(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            _logger.LogError("Customer not found while trying to delete");
            throw new NotFoundException("Customer for delete");
        }

        public async Task<Customer> Get(int key)
        {
            var customer = _context.customers.FirstOrDefault(c => c.Id == key);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _context.customers.ToListAsync();
            if (customers.Count == 0)
            {
                throw new CollectionEmptyException("Customers");
            }
            return customers;
        }

        public async Task<Customer> Update(int key, Customer entity)
        {
            var customer = await Get(key);
            if (customer != null)
            {
                customer.Name = entity.Name;
                customer.Address = entity.Address;
                customer.Phone = entity.Phone;
                await _context.SaveChangesAsync();
                return customer;
            }
            throw new NotFoundException("Customer for delete");
        }
    }
}
