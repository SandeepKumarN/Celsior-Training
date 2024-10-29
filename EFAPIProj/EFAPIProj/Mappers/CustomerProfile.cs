using AutoMapper;
using EFAPIProj.Models;
using EFAPIProj.DTOs;

namespace EFAPIProj.Mappers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
