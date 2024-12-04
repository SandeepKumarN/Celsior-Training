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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(ISupplierService supplierService, ILogger<SupplierController> logger)
        {
            _supplierService = supplierService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] SupplierDTO supplier)
        {
            try
            {
                var supplierId = await _supplierService.Add(supplier);
                _logger.LogInformation($"Supplier created with id {supplierId}");
                return Ok(supplierId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating admin");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{supplierId}")]
        public async Task<IActionResult> Get(int supplierId)
        {
            try
            {
                var supplier = await _supplierService.Get(supplierId);
                if (supplier == null)
                {
                    _logger.LogWarning($"Supplier with ID {supplierId} not found.");
                    return NotFound($"Supplier with ID {supplierId} not found.");
                }
                _logger.LogInformation($"Supplier with ID {supplierId} retrieved successfully.");
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}
