using Moq;
using PostgresEF.Controllers.API;
using PostgresEF.Interfaces;
using PostgresEF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PostgresEFTests
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeRepository> employeeServiceMock;

        public EmployeeControllerTests()
        {
            employeeServiceMock = new Mock<IEmployeeRepository>();
        }

        [Fact]
        public async void GetEmployeeById_ShouldReturnEmployeeName()
        {
            var expected = "Vinh";
            employeeServiceMock.Setup(e => e.GetEmployeeById(It.IsAny<int>())).ReturnsAsync(expected);
            var controller = new EmployeeController(employeeServiceMock.Object);

            var result = await controller.GetEmployeeById(1);

            Assert.Equal(expected, result);
        }

        [Fact]
        public async void GetEmployeeById_ShouldReturnNothing()
        {
            employeeServiceMock.Setup(e => e.GetEmployeeById(-1)).ReturnsAsync((string) null);
            var controller = new EmployeeController(employeeServiceMock.Object);

            var result = await controller.GetEmployeeById(-1);

            Assert.Null(result);
        }

        [Fact]
        public async void GetEmployeeDetails_ShouldReturnEmployeeObject()
        {
            var employeeDto = new Employee()
            {
                Id = 1,
                Name = "Vinh",
                Designation = "SDE"
            };
            employeeServiceMock.Setup(e => e.GetEmployeeDetails(1)).ReturnsAsync(employeeDto);

            var controller = new EmployeeController(employeeServiceMock.Object);

            var result = await controller.GetEmployeeDetails(1);

            Assert.Equal(employeeDto, result);
        }

        [Fact]
        public async void GetEmployeeDetails_ShouldReturnNull()
        {
            employeeServiceMock.Setup(e => e.GetEmployeeDetails(1)).ReturnsAsync((Employee) null);

            var controller = new EmployeeController(employeeServiceMock.Object);

            var result = await controller.GetEmployeeDetails(-1);

            Assert.Null(result);
        }
    }
}
