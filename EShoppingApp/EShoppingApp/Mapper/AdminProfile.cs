using AutoMapper;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Models;

namespace EShoppingApp.Mapper
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminDTO>();
            CreateMap<AdminDTO, Admin>();
        }
    }
}
