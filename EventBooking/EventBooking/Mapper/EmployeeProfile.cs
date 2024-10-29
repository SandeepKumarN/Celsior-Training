using EventBooking.Models.DTO;
using EventBooking.Models;
using AutoMapper;

namespace EventBooking.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
