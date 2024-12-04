using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;

namespace EShoppingApp.Interfaces
{
    public interface ICustomerService
    {
        Task<int> AddCustomer(CustomerDTO customer);
        Task<Customer> GetCustomer(int customerId);
        Task<Customer> UpdateCustomer(int customerId, CustomerUpdateDTO customerDto);
        Task<bool> DeleteCustomer(int customerId);

    }
}
