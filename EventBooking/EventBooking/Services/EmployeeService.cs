using AutoMapper;
using EventBooking.Interfaces;
using EventBooking.Models;
using EventBooking.Models.DTO;
using EventBooking.Repositories;

namespace EventBooking.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<int, Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;      
        }

        
        public async Task<IEnumerable<Employee>> GetAllEmployeeList()
        {
            try
            {
                var Employee = await _repository.GetAll();
                return Employee;
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
                var employeeData = _mapper.Map<Employee>(n_Employee);
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
