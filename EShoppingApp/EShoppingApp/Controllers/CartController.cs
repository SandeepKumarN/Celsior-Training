using EShoppingApp.Interfaces;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ILogger<CartController> _logger;

        public CartController(ICartService cartService, ILogger<CartController> logger)
        {
            _cartService = cartService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] CartDTO cart)
        {
            try
            {
                var cartId = await _cartService.Add(cart);
                _logger.LogInformation($"Cart created with id {cartId}");
                return Ok(cartId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating cart");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var cart = await _cartService.Get(Id);
                if (cart == null)
                {
                    _logger.LogWarning($"Cart with ID {Id} not found.");
                    return NotFound($"Cart with ID {Id} not found.");
                }
                _logger.LogInformation($"Cart with ID {Id} retrieved successfully.");
                return Ok(cart);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> Delete(int cartId)
        {
            try
            {
                var result = await _cartService.Delete(cartId);
                if (result)
                {
                    return NoContent();
                }

                return NotFound(new { message = $"Cart with ID {cartId} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", error = ex.Message });
            }
        }
    }
}
