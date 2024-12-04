using AutoMapper;
using Castle.Core.Resource;
using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;

namespace EShoppingApp.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
