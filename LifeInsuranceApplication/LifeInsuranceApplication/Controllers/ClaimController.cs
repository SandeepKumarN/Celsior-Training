using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LifeInsuranceApplication.Migrations;
using Microsoft.AspNetCore.Authorization;

namespace LifeInsuranceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewClaims([FromForm] ClaimDTO Claim)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .Select(e => new
                        {
                            Key = e.Key,
                            Errors = e.Value.Errors.Select(err => err.ErrorMessage).ToArray()
                        })
                        .ToList();

                    return BadRequest(new { Message = "Validation failed", Errors = errors });
                }

                var createdClaimId = await _claimService.CreateNewClaims(Claim);
                return Ok(new ResponseNewCreated
                {
                    Id = createdClaimId,
                    Message = "A new claim is created"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }


            //try
            //{
            //        var claim = await _claimService.CreateNewClaims(Claim);
            //        return Ok(new ResponseNewCreated
            //        {
            //            Id = claim,
            //            Message = "A new claim is created"
            //        });

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(StatusCode(StatusCodes.Status500InternalServerError, ex.Message));
            //}
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClaims()
        {
            try
            {
                var claim = await _claimService.GetAllClaims();
                return Ok(claim);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateStatus(UpdateStatusDTO updateStatusDTO)
        {
            try
            {
                var claim = await _claimService.UpdateStatus(updateStatusDTO);
                return Ok(claim);
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCode(500, ex.Message));
            }
        }
    }
}
