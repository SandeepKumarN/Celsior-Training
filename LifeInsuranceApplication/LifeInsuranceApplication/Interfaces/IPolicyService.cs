using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Interfaces
{
    public interface IPolicyService
    {
        public Task<int> CreateNewPolicies(PolicyDTO policy);
        public  Task<int> GetPolicyById(int policyId);
        public Task<IEnumerable<Policy>> GetAllPolicies();
        public Task<int> DeletePolicyId(int policyId);
    }
}
