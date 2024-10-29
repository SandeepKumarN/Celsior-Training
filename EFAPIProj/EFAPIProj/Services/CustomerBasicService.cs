using EFAPIProj.Models;
using EFAPIProj.Interfaces;
using EFAPIProj.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFAPIProj.Services
{
    public class CustomerBasicService
    {
        private readonly IRepository<int, Customer> _customerRepository;

        public CustomerBasicService(IRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Get a customer by ID
        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _customerRepository.Get(id);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID {id} not found.");
            }
            return customer;
        }

        // Get all customers
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAll();
            if (customers == null)
            {
                throw new CollectionEmptyException("No customers found.");
            }
            return customers;
        }

        // Add a new customer
        public async Task<Customer> AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new CouldNotAddException("Customer cannot be null.");
            }
            return await _customerRepository.Add(customer);
        }

        // Update an existing customer
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new CouldNotAddException("Customer cannot be null.");
            }

            var existingCustomer = await _customerRepository.Get(customer.Id);
            if (existingCustomer == null)
            {
                throw new NotFoundException($"Customer with ID {customer.Id} not found.");
            }

            return await _customerRepository.Update(customer);
        }

        // Delete a customer by ID
        public async Task<Customer> DeleteCustomer(int id)
        {
            var existingCustomer = await _customerRepository.Get(id);
            if (existingCustomer == null)
            {
                throw new NotFoundException($"Customer with ID {id} not found.");
            }

            return await _customerRepository.Delete(id);
        }
    }
}

