using AutoMapper;
using Employee_Management_API.Models;
using Employee_Management_API.DTO;

namespace Employee_Management_API.AutoMapper
{
    public class EmployeeMapper:Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, EmployeeUserDTO>().ReverseMap();
            CreateMap<Employee, EmployeeAdminDTO>().ReverseMap();
        }
    }
}
