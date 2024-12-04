using EShoppingApp.Models.DTOs;

namespace EShoppingApp.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(UserTokenDTO user);
    }
}
