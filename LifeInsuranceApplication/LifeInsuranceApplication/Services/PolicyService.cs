using AutoMapper;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IRepository<int, Policy> _policyRepository;
        private readonly IMapper _mapper;


        public PolicyService(IRepository<int, Policy> policyRepository, IMapper mapper)
        {
            _policyRepository = policyRepository;
            _mapper = mapper;

        }

        public async Task<int> CreateNewPolicies(PolicyDTO policy)
        {
            Policy myPolicy = _mapper.Map<Policy>(policy);
            myPolicy = await _policyRepository.Add(myPolicy);
            return myPolicy.Id;
        }
        public async Task<int> DeletePolicyId(int policyId)
        {
            Policy myPolicy = _mapper.Map<Policy>(policyId);
            myPolicy = await _policyRepository.Add(myPolicy);
            return myPolicy.Id;
        }

        public async Task<IEnumerable<Policy>> GetAllPolicies()
        {

            var myPolicy = await _policyRepository.GetAll();
            return myPolicy;
        }

        public async Task<int> GetPolicyById(int policyId)
        {
            Policy myPolicy = _mapper.Map<Policy>(policyId);
            myPolicy = await _policyRepository.Add(myPolicy);
            return myPolicy.Id;
        }
    }
}
