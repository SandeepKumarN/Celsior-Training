using EFAPIProj.Interfaces;
using EFAPIProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFAPIProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<int, Customer> _customerRepository;

        public CustomerController(IRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Get all customers
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAll();
            return Ok(customers);
        }

        // Get customer by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.Get(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // Add new customer
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            if (customer == null)
                return BadRequest();

            var addedCustomer = await _customerRepository.Add(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = addedCustomer.Id }, addedCustomer);
        }

        // Update customer
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
                return BadRequest();

            var updatedCustomer = await _customerRepository.Update(id, customer);
            return Ok(updatedCustomer);
        }

        // Delete customer
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deletedCustomer = await _customerRepository.Delete(id);
            if (deletedCustomer == null)
                return NotFound();

            return NoContent();
        }
    }
}
