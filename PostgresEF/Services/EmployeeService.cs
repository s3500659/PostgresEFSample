using Microsoft.EntityFrameworkCore;
using PostgresEF.Data;
using PostgresEF.Interfaces;
using PostgresEF.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresEF.Services
{
    public class EmployeeService : IEmployeeService
    {
        #region Property
        private readonly IDataContext _dbContext;
        #endregion

        #region Constructor 
        public EmployeeService(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        public async Task<string> GetEmployeeById(int empId)
        {
            var name = await _dbContext.Employees
                .Where(e => e.Id == empId)
                .Select(e => e.Name)
                .FirstOrDefaultAsync();

            return name;
        }

        public async Task<Employee> GetEmployeeDetails(int empId)
        {
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == empId);

            return emp;
        }
    }
}
