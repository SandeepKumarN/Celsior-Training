using EventBooking.Interfaces;
using EventBooking.Models;
using EventBooking.Models.DTO;
using EventBooking.Properties.Contexts;
using EventBooking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPIOct24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly EmployeeService _userService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            try
            {
                var events = await _eventService.GetAllEventList();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("/eventName")]
        public async Task<IActionResult> getEventNames()
        {
            try
            {
                var events = await _eventService.GetAllEventList();
                //linq query to fetch to only event names
                var eventsnames = (from enames in events
                                   select enames.Title).ToList();
                return Ok(eventsnames);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("/getEventWithUser")]
        public async Task<IActionResult> getEventNameAndUser()
        {
            try
            {
                var events = await _eventService.GetAllEventList();
                //linq query to fetch to only event names
                var eventsnames = (from enames in events
                                   select enames.Title).ToList();
                return Ok(eventsnames);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventDTO EventDTO)
        {
            try
            {

                var user = await _eventService.CreateNewEvent(EventDTO);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
