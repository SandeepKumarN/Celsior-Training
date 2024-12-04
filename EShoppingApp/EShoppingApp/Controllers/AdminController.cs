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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] AdminDTO admin)
        {
            try
            {
                var adminId = await _adminService.Add(admin);
                _logger.LogInformation($"Admin created with id {adminId}");
                return Ok(adminId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating admin");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{adminId}")]
        public async Task<IActionResult> Get(int adminId)
        {
            try
            {
                var admin = await _adminService.Get(adminId);
                if (admin == null)
                {
                    _logger.LogWarning($"Customer with ID {adminId} not found.");
                    return NotFound($"Customer with ID {adminId} not found.");
                }
                _logger.LogInformation($"Customer with ID {adminId} retrieved successfully.");
                return Ok(admin);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPut("updateAdmin")]
        [Authorize]
        public async Task<IActionResult> Update(int adminId, AdminUpdateDTO adminDto)
        {
            if (adminDto == null)
            {
                return BadRequest("Admin data is required.");
            }
            try
            {
                var updatedAdmin = await _adminService.Update(adminId, adminDto);
                return Ok(updatedAdmin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", error = ex.Message });
            }
        }

        [HttpDelete("{adminId}")]
        public async Task<IActionResult> Delete(int adminId)
        {
            try
            {
                var result = await _adminService.Delete(adminId);
                if (result)
                {
                    return NoContent();
                }

                return NotFound(new { message = $"Admin with ID {adminId} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", error = ex.Message });
            }
        }
    }
}
