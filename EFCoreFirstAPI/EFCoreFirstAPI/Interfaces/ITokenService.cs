using EFCoreFirstAPI.Models.DTOs;
using Moq;

namespace EFCoreFirstAPI.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(UserTokenDTO user);
       // public Mock<ITokenService> tokenService;
    }
}
