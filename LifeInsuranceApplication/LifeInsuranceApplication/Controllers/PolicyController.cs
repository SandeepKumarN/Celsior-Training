using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Migrations;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeInsuranceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;
        private readonly ILogger<PolicyController> _logger;

        public PolicyController(IPolicyService policyService, ILogger<PolicyController> logger)
        {
            _policyService = policyService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPolicies(PolicyDTO Policy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var policy = await _policyService.CreateNewPolicies(Policy);
                    return Ok(new ResponseNewCreated
                    {
                        Id = policy,
                        Message = "A new policy is created"
                    });
                }
                else
                {
                    return BadRequest(new ResponseNewCreated
                    {
                        Message = "Invalid"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCode(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPolicies()
        {
            try
            {
                var policies = await _policyService.GetAllPolicies();
                return Ok(policies);
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCode(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

    }
}
