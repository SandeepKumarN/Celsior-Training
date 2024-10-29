using EventBooking.Interfaces;
using EventBooking.Models.DTO;
using EventBooking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly EmployeeService _userService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            try
            {
                var bookings = await _bookingService.GetAllBookingList();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("/bookingName")]
        public async Task<IActionResult> getBookingNames()
        {
            try
            {
                var bookings = await _bookingService.GetAllBookingList();
                //linq query to fetch to only booking names
                var bookingsnames = (from enames in bookings
                                   select enames.EventId).ToList();
                return Ok(bookingsnames);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("/getBookingWithUser")]
        public async Task<IActionResult> getBookingNameAndUser()
        {
            try
            {
                var events = await _bookingService.GetAllBookingList();
                //linq query to fetch to only event names
                var eventsnames = (from enames in events
                                   select enames.EventId).ToList();
                return Ok(eventsnames);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingDTO BookingDTO)
        {
            try
            {

                var booking = await _bookingService.CreateNewBooking(BookingDTO);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
