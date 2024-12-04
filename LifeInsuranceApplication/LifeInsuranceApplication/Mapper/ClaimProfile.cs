using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Models;
using AutoMapper;

namespace LifeInsuranceApplication.Mapper
{
    public class ClaimProfile : Profile
    {
        public ClaimProfile()
        {
            CreateMap<Claim, ClaimDTO>();
            CreateMap<ClaimDTO, Claim>();
        }
    }
}
