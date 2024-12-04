using AutoMapper;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Models;

namespace EShoppingApp.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
