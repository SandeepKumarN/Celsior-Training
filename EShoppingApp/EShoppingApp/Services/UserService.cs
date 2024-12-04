using EShoppingApp.EmailInterface;
using EShoppingApp.EmailModels;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace EShoppingApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<string, User> _userRepository;
        private readonly ILogger<UserService> _logger;

        private readonly ITokenService _tokenService;
        private readonly IEmailSender _emailSender;

        public UserService(IRepository<string, User> userRepository,
            ITokenService tokenService,
            ILogger<UserService> logger, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _logger = logger;
            _tokenService = tokenService;
            _emailSender = emailSender;


        }
        public async Task<LoginResponseDTO> Autheticate(LoginRequestDTO loginUser)
        {
            var user = await _userRepository.Get(loginUser.Username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            HMACSHA256 hmac = new HMACSHA256(user.HashKey);
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));
            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != user.Password[i])
                {
                    throw new Exception("Invalid username or password");
                }
            }
            return new LoginResponseDTO()
            {
                Username = user.Username,
                Token = await _tokenService.GenerateToken(new UserTokenDTO()
                {
                    Username = user.Username,
                    Role = user.Role.ToString()
                })

            };
        }

        public async Task<LoginResponseDTO> Register(UserCreateDTO registerUser)
        {
            HMACSHA256 hmac = new HMACSHA256();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password));
            User user = new User
            {
                Id = registerUser.Id,
                Username = registerUser.Username,
                Password = passwordHash,
                Email = registerUser.Email,
                HashKey = hmac.Key,
                Role = registerUser.Role
            };
            try
            {
                var addesUser = await _userRepository.Add(user);
                LoginResponseDTO response = new LoginResponseDTO()
                {
                    Username = user.Username
                };
                var rng = new Random();
                var message = new Message(new string[]
                {
                    user.Email },
                    $"User Registered Successfully",
                    $"Hello {addesUser.Username},\r\n\r\n" +
                    "Welcome to the EShopping App!\r\n\r\n" +
                    "Your account has been successfully registered.\r\n\r\n" +
                    "If you did not register for this account or believe there is an issue, " +
                    "please contact our support team immediately.\r\n\r\n" +
                    "Thank you for choosing EShopping App! " +
                    "We look forward to providing you with a great shopping experience.\r\n\r\n" +
                    "Best regards,\r\nThe EShopping App Team");
                _emailSender.SendEmail(message);
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not register user");
                throw new Exception("Could not register user");
            }
        }
    }
}
