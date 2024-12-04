using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Models;

namespace LifeInsuranceApplication.Interfaces
{
    public interface IClaimService
    {
        public Task<int> CreateNewClaims(ClaimDTO claimDto);
        public Task<IEnumerable<Claim>> GetAllClaims();
        public Task<Claim> UpdateStatus(UpdateStatusDTO updateStatusDTO);

    }
}
