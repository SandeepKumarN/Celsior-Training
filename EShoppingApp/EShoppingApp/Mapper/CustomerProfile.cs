using EShoppingApp.Models.DTOs;
using EShoppingApp.Models;
using AutoMapper;

namespace EShoppingApp.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
