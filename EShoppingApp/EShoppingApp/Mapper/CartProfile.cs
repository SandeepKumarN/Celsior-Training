using EShoppingApp.Models.DTOs;
using EShoppingApp.Models;
using AutoMapper;

namespace EShoppingApp.Mapper
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartDTO>();
            CreateMap<CartDTO, Cart>();
        }
    }
}
