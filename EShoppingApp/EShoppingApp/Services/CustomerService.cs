using AutoMapper;
using EShoppingApp.Exceptions;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Repositories;
using MailKit.Search;

namespace EShoppingApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<int, Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<int, Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<int> AddCustomer(CustomerDTO customer)
        {           
                // Map DTO to Customer model
                var customers = _mapper.Map<Customer>(customer);

                // Add customer using repository
                var addedCustomer = await _customerRepository.Add(customers);

                // Return the ID of the added customer
                return addedCustomer.Id;            
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            var deletedCustomer = await _customerRepository.Delete(customerId);

            // Return true if the deletion was successful
            return deletedCustomer != null;
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            var customer = await _customerRepository.Get(customerId);
            return customer;
        }

        public async Task<Customer> UpdateCustomer(int customerId, CustomerUpdateDTO customerDto)
        {
            var customer = new Customer
            {
                Address = customerDto.Address,
                Name = customerDto.Name,
                Phone = customerDto.Phone,
                Email = customerDto.Email
            };
            var updatedCustomer = await _customerRepository.Update(customerId, customer);
            return updatedCustomer;
        }
    }
}
