using AutoMapper;
using EventBooking.Models;
using EventBooking.Models.DTO;

namespace EventBooking.Mapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventDTO, Event>();
            CreateMap<Event, EventDTO>();
        }
    }
}
