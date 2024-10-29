using AutoMapper;
using EventBooking.Interfaces;
using EventBooking.Models.DTO;
using EventBooking.Models;

namespace EventBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<int, BookingDTO> _repository;
        private readonly IMapper _mapper;

        public BookingService(IRepository<int, Booking> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Booking>> GetAllBookingList()
        {
            try
            {
                var booking = await _repository.GetAll();
                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee> CreateNewEmployee(EmployeeDTO n_Employee)
        {
            try
            {
                var employeeData = _mapper.Map<Booking>(n_Employee);
                var newEmployee = await _repository.Add(employeeData);
                return newEmployee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
