using EShoppingApp.Models.DTOs;
using EShoppingApp.Models;
using AutoMapper;

namespace EShoppingApp.Mapper
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierDTO, Supplier>();
        }
    }
}
