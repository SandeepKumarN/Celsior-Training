using EventBooking.Models.DTO;
using EventBooking.Models;
using AutoMapper;

namespace EventBooking.Mapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingDTO, Booking>();
            CreateMap<Booking, BookingDTO>();
        }
    }
}
