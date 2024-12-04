using EShoppingApp.Exceptions;
using EShoppingApp.Interfaces;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddCustomer([FromBody] CustomerDTO customer)
        {
            try
            {
                var customerId = await _customerService.AddCustomer(customer);
                _logger.LogInformation($"Customer created with id {customerId}");
                return Ok(customerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating customer");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{customerId}")]
        [Authorize]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            try
            {
                var customer = await _customerService.GetCustomer(customerId);
                if (customer == null)
                {
                    _logger.LogWarning($"Customer with ID {customerId} not found.");
                    return NotFound($"Customer with ID {customerId} not found.");
                }
                _logger.LogInformation($"Customer with ID {customerId} retrieved successfully.");
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPut("updateCustomer")]
        [Authorize]
        public async Task<IActionResult> UpdateCustomer(int customerId,  CustomerUpdateDTO customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest("Customer data is required.");
            }
            try
            {
                var updatedCustomer = await _customerService.UpdateCustomer(customerId, customerDto);
                return Ok(updatedCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", error = ex.Message });
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            try
            {
                var result = await _customerService.DeleteCustomer(customerId);
                if (result)
                {
                    return NoContent(); // Customer deleted successfully
                }

                return NotFound(new { message = $"Customer with ID {customerId} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", error = ex.Message });
            }
        }
    }
}
