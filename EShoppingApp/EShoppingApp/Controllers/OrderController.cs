using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Repositories;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PlaceOrder(OrderDTO orderDto)
        {
            try
            {
                if (orderDto == null)
                {
                    _logger.LogWarning("Received null order data.");
                    return BadRequest("Order data is required.");
                }

                // Call the service to add the order
                var result = await _orderService.PlaceOrderAsync(orderDto);

                // Log the success
                //_logger.LogInformation($"Order with ID {result.Id} placed successfully.");

                // Return the result

                //return Ok($"Order with ID {result.Id} placed successfully.");
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError($"An error occurred while placing the order: {ex.Message}");
                return BadRequest($"Error placing order: {ex.Message}");
            }
        }

        [HttpGet("{orderId}")]
        [Authorize]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            try
            {

                // Call the service to get the order by its ID
                var order = await _orderService.GetOrderByIdAsync(orderId);

                // Check if the order was found
                if (order == null)
                {
                    _logger.LogWarning($"Order with ID {orderId} not found.");
                    return NotFound($"Order with ID {orderId} not found.");
                }


                // Log the success
                 _logger.LogInformation($"Order with ID {orderId} retrieved successfully.");

                // Return the order
                return Ok(order);
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{orderId}")]
        [Authorize]
        public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] OrderDTO orderDto)
        {

            try
            {
                if (orderDto == null)
                { 
                    _logger.LogWarning("Received null order data for update.");
                    return BadRequest("Order data is required.");
                }

                // Call the service to update the order
                var updatedOrder = await _orderService.UpdateOrderAsync(orderId, orderDto);

                // Check if the order exists
                if (updatedOrder == null)
                {
                    _logger.LogWarning($"Order with ID {orderId} not found for update.");
                    return NotFound($"Order with ID {orderId} not found.");
                }

                // Log the success
                _logger.LogInformation($"Order with ID {orderId} updated successfully.");

                // Return the updated order
                return Ok(updatedOrder);
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError($"An error occurred while updating the order with ID {orderId}: {ex.Message}");
                return BadRequest($"Error updating order: {ex.Message}");
            }
        }



        [HttpDelete("{orderId}")]
        [Authorize]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            try
            {
                // Check if the order exists before attempting to delete
                var order = await _orderService.GetOrderByIdAsync(orderId);

                if (order == null)
                {
                    _logger.LogWarning($"Order with ID {orderId} not found for deletion.");
                    return NotFound($"Order with ID {orderId} not found.");
                }

                // Call the service to delete the order
                var deletedOrder = await _orderService.DeleteOrderAsync(orderId);

                // Log the success
                _logger.LogInformation($"Order with ID {orderId} deleted successfully.");

                // Return NoContent status as no content is returned on successful deletion
                return Ok(deletedOrder);
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError($"An error occurred while deleting the order with ID {orderId}: {ex.Message}");
                return BadRequest($"Error deleting order: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetOrdersByUserId(int customerId)
        {
            try
            {
                var orders = await _orderService.GetOrdersByUserIdAsync(customerId);
                
                if (orders == null)
                {
                    _logger.LogInformation($"No orders found for user with ID {customerId}.");
                    return NotFound($"No orders found for user with ID {customerId}.");
                }

                _logger.LogInformation($"Retrieved {orders.Count} orders for user with ID {customerId}.");

                return Ok(orders);
            }
            catch (Exception ex)
            {

               _logger.LogError($"An error occured while fetching orders for user with ID {customerId}: {ex.Message}");
                return BadRequest($"Error fetching orders {ex.Message}");
            }
        }

    }
}
