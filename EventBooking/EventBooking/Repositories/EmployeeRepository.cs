using EventBooking.Interfaces;
using EventBooking.Models;
using EventBooking.Properties.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee entity)
        {
            try
            {
                _context.Employees.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee> Delete(int key)
        {
            try
            {
                var Employee = await Get(key);
                if (Employee != null)
                {
                    _context.Employees.Remove(Employee);
                    await _context.SaveChangesAsync();
                    return Employee;
                }
                throw new Exception("Delete error");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee> Get(int key)
        {
            try
            {
                var Employee = await _context.Employees.FirstOrDefaultAsync(c => c.Id == key);
                return Employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var Employees = await _context.Employees.ToListAsync();
            if (Employees.Count == 0)
            {
                throw new Exception("There is no user");
            }
            return Employees;
        }

        public async Task<Employee> Update(int key, Employee entity)
        {
            var Employee = await Get(key);
            if (Employee != null)
            {
                Employee.Name = entity.Name;
                Employee.Email = entity.Email;
                await _context.SaveChangesAsync();
                return Employee;
            }
            //throw new NotFoundException("Customer for delete");
            throw new Exception("message");
        }

    }
}