using AutoMapper;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Repositories;

namespace LifeInsuranceApplication.Services
{
    public class ClaimTypeService : IClaimTypeService
    {
        private readonly IRepository<int, ClaimType> _claimTypeRepository;
        private readonly IMapper _mapper;

        public ClaimTypeService(IRepository<int, ClaimType> claimTypeRepository, IMapper mapper)
        {
            _claimTypeRepository = claimTypeRepository;
            _mapper = mapper;

        }

        public async Task<int> CreateNewClaimTypes(ClaimTypeDTO claimType)
        {
            ClaimType myClaimType = _mapper.Map<ClaimType>(claimType);
            myClaimType = await _claimTypeRepository.Add(myClaimType);
            return myClaimType.Id;
        }

        public async Task<IEnumerable<ClaimType>> GetAllClaimTypes()
        {

            var myClaimType = await _claimTypeRepository.GetAll();
            return myClaimType;
        }

        //public async Task<int> DeleteClaimTypeId(int claimTypeId)
        //{
        //    ClaimType myClaimType = _mapper.Map<ClaimType>(claimTypeId);
        //    myClaimType = await _claimTypeRepository.Add(myClaimType);
        //    return myClaimType.Id;
        //}

        

        //public async Task<int> GetClaimTypeById(int claimTypeId)
        //{

        //    ClaimType myClaimType = _mapper.Map<ClaimType>(claimTypeId);
        //    myClaimType = await _claimTypeRepository.Add(myClaimType);
        //    return myClaimType.Id;
        //}
    }
}
