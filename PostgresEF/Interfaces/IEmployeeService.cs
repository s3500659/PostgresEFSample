using PostgresEF.Models.Entities;
using System.Threading.Tasks;

namespace PostgresEF.Interfaces
{
    public interface IEmployeeService
    {
        Task<string> GetEmployeeById(int empId);
        Task<Employee> GetEmployeeDetails(int empId);

    }
}
