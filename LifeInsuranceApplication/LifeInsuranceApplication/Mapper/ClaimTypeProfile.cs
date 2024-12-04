using AutoMapper;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Models;

namespace LifeInsuranceApplication.Mapper
{
    public class ClaimTypeProfile : Profile
    {
        public ClaimTypeProfile()
        {
            CreateMap<ClaimType, ClaimTypeDTO>();
            CreateMap<ClaimTypeDTO, ClaimType>();
        }
    }
}
