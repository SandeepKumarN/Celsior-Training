using EventBooking.Models.DTO;
using EventBooking.Models;

namespace EventBooking.Interfaces
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAllEmployeeList();
        public Task<Employee> CreateNewEmployee(EmployeeDTO n_Employee);
    }
}
