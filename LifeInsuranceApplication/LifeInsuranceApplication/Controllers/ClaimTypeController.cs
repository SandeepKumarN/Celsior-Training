using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeInsuranceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimTypeController : ControllerBase
    {
        private readonly IClaimTypeService _claimTypeService;

        public ClaimTypeController(IClaimTypeService claimTypeService)
        {
            _claimTypeService = claimTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewClaimTypes(ClaimTypeDTO ClaimType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var claimType = await _claimTypeService.CreateNewClaimTypes(ClaimType);
                    return Ok(new ResponseNewCreated
                    {
                        Id = claimType,
                        Message = "A new claimType is created"
                    });
                }
                else
                {
                    return BadRequest(new ResponseNewCreated
                    { Message = "Invalid" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCode(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClaimTypes()
        {
            try
            {
                var claimTpyes = await _claimTypeService.GetAllClaimTypes();
                return Ok(claimTpyes);
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCode(StatusCodes.Status400BadRequest, ex.Message));
            }
        }
    }
}
