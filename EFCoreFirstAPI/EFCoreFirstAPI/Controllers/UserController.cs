using EFCoreFirstAPI.Interfaces;
using EFCoreFirstAPI.Misc;
using EFCoreFirstAPI.Models.DTOs;
using EFCoreFirstAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [CustomExceptionFilter]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController( IUserService userService,ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<LoginResponseDTO>> RegisterUser(UserCreateDTO createDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userService.Register(createDTO);
                    return Ok(user);
                }
                else
                {
                    return BadRequest(new ErrorResponseDTO
                    {
                        ErrorMessage = "one or more validation errors",
                        ErrorNumber = 400
                    });
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not register user");
                return BadRequest(new ErrorResponseDTO
                {
                    ErrorMessage = e.Message,
                    ErrorNumber = 500
                });
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO requestDTO)
        {
            try
            {
                var user = await _userService.Autheticate(requestDTO);
                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Invalid username or password");
                return Unauthorized(new ErrorResponseDTO
                {
                    ErrorMessage = e.Message,
                    ErrorNumber = 401
                });
            }
        }
    }
}