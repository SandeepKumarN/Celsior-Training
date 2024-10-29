using EventBooking.Models.DTO;
using EventBooking.Models;

namespace EventBooking.Interfaces
{
    public interface IBookingService
    {
        public Task<IEnumerable<Booking>> GetAllBookingList();
        public Task<Booking> CreateNewBooking(BookingDTO n_booking);
    }
}
