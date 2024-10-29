using EventBooking.Interfaces;
using EventBooking.Models;
using EventBooking.Models.DTO;
using EventBooking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly EmployeeService _userService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeeList();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("/employeeName")]
        public async Task<IActionResult> getEmployeeNames()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeeList();
                //linq query to fetch to only employee names
                var employeesnames = (from enames in employees
                                   select enames.Name).ToList();
                return Ok(employeesnames);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("/getEmployeeWithUser")]
        public async Task<IActionResult> getEmployeeNameAndUser()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeeList();
                //linq query to fetch to only employee names
                var employeesnames = (from enames in employees
                                   select enames.Name).ToList();
                return Ok(employeesnames);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO EmployeeDTO)
        {
            try
            {

                var Employee = await _employeeService.CreateNewEmployee(EmployeeDTO);
                return Ok(Employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
