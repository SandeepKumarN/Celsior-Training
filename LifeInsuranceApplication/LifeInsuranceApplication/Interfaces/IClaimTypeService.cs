using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Models;

namespace LifeInsuranceApplication.Interfaces
{
    public interface IClaimTypeService
    {
        public Task<int> CreateNewClaimTypes(ClaimTypeDTO claimType);
        public Task<IEnumerable<ClaimType>> GetAllClaimTypes();
       // public Task<int> GetClaimTypeById(int claimTypeId);
       // public Task<int> DeleteClaimTypeId(int claimTypeId);

    }
}
