using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(UserTokenDTO user);
    }
}
