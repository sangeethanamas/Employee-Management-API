using Employee_Management_API.DTO;
using Employee_Management_API.Interface;
using Employee_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_API.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly EmployeeManagementApiContext _context;

       
        public EmployeeRepository(EmployeeManagementApiContext context)
        {
            _context = context;
            
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            var getid = await _context.Employees.FindAsync(id);
            
             _context.Employees.Remove(getid);
           await _context.SaveChangesAsync();
            return getid;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
           
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int pagenumber,int pagesize)
        {
           return await _context.Employees.Skip((pagenumber - 1) *pagesize).Take(pagesize)
                .ToListAsync();
        }

       
        public async Task<Employee> UpdateAdminEmployeeAsync(int id, EmployeeAdminDTO employee)
        {
            var getid = await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();

            getid.Name = employee.Name;
            getid.Department = employee.Department;
            getid.Salary = employee.Salary;


            await _context.SaveChangesAsync();
            return getid;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, EmployeeUserDTO employee)
        {
            var getid = await _context.Employees.FindAsync(id);
            
            getid.Name= employee.Name;
            getid.City = employee.City;
            _context.Employees.Update(getid);
            await _context.SaveChangesAsync();
            return getid;
            
            
        }

        
    }
}
