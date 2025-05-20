using AutoMapper;
using Employee_Management_API.AutoMapper;
using Employee_Management_API.DTO;
using Employee_Management_API.Interface;
using Employee_Management_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Employee_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public EmployeeController(IEmployee employee, IMapper mapper, HttpClient httpClient)
        {
            _employee = employee;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee(int pagenumber = 1, int pagesize = 10)
        {
            var employee = await _employee.GetEmployeesAsync(pagenumber, pagesize);
            //var employeedto = _mapper.Map<List<EmployeeAdminDTO>>(employee);
            //return Ok(employeedto);
            return Ok(employee);
        }

        [HttpGet("employee/{id}")]

        public async Task<IActionResult> GetEmployeeID(int id)
        {
            var getid = await _employee.GetEmployeeByIdAsync(id);
            if (getid == null)
            {
                return NotFound();
            }
            //var getiddto = _mapper.Map<EmployeeUserDTO>(getid);
            //return Ok(getiddto);
            return Ok(getid);
        }



        [HttpPost]

        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            var employeeadd = await _employee.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(AddEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("Admin/{id}")]

        public async Task<IActionResult> UpdateEmployee(int  id, [FromBody] EmployeeAdminDTO employee)
        {
            var getid = await _employee.UpdateAdminEmployeeAsync(id,employee);
            
            if (getid == null)
            {
                return NotFound();
            }

            

            var updatedto=_mapper.Map<EmployeeAdminDTO>(getid);
            return NoContent();

            //if (getid == null)
            //{
            //    return NotFound();
            //}
            // return getid==null ? NotFound() : Ok(_mapper.Map<Employee>(getid));
            //   return update == null ? NotFound() : Ok(update);
        }

      


        [HttpPut("User")]

        public async Task<IActionResult> UpdateUserEmployee(int id, [FromBody] EmployeeUserDTO employee)
        {
            var getid = await _employee.UpdateEmployeeAsync(id, employee);
            if (getid == null)
            {
                return NotFound();
            }

            var updatedto = _mapper.Map<EmployeeUserDTO>(getid);
            return Ok(updatedto);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var getid = await _employee.DeleteEmployeeAsync(id);
            if (getid == null)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpGet("weather/{city}")]
        public async Task<string> Gettemperature(string city)
        {
            //var requesturl = $"https://wttr.in/{city}?format=%l:%t:%C:%c";
            var requesturl = $"https://wttr.in/{city}?format=%t:%C";
            var response = await _httpClient.GetAsync(requesturl);
            if (!response.IsSuccessStatusCode)
            {
                return "Weather data not available";
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            return "The temperature in "+city+ "is"+ responseContent;
        }
    }
}
