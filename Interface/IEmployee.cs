using Employee_Management_API.Models;
using Employee_Management_API.DTO;

namespace Employee_Management_API.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(int pagenumber,int pagesize);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(int id,EmployeeUserDTO employee);

        Task<Employee> UpdateAdminEmployeeAsync(int id, EmployeeAdminDTO employee);

        Task<Employee> DeleteEmployeeAsync(int id);
        //Task<string> Gettemperature(string city);

    }
}
