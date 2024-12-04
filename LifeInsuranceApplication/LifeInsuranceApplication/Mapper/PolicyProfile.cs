using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using AutoMapper;

namespace LifeInsuranceApplication.Mapper
{
    public class PolicyProfile : Profile
    {
        public  PolicyProfile()
        {
            CreateMap<Policy, PolicyDTO>();
            CreateMap<PolicyDTO, Policy>();
        }
    }
    
    
}
