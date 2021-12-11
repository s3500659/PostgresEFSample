using Microsoft.AspNetCore.Mvc;
using PostgresEF.Interfaces;
using PostgresEF.Models.Entities;
using System.Threading.Tasks;

namespace PostgresEF.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeService;

        public EmployeeController(IEmployeeRepository employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<string> GetEmployeeById(int empId)
        {
            var result = await _employeeService.GetEmployeeById(empId);

            return result;
        }

        [HttpGet("id")]
        public async Task<Employee> GetEmployeeDetails(int empId)
        {
            var result = await _employeeService.GetEmployeeDetails(empId);

            return result;
        }
    }
}
