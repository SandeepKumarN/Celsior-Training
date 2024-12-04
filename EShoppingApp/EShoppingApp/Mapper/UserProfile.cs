using AutoMapper;
using Castle.Core.Resource;
using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;

namespace EShoppingApp.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
