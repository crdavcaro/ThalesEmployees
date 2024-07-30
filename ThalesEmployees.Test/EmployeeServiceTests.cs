using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using ThalesEmployees.Business.Repositories;
using ThalesEmployees.Business.Services;
using ThalesEmployees.Model.Entities;
using ThalesEmployees.Business.Dtos;

namespace ThalesEmployees.Test
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private EmployeeService _employeeService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IEmployeeRepository>();
            _mockMapper = new Mock<IMapper>();
            _employeeService = new EmployeeService(_mockRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsMappedEmployeeDtos()
        {
            // Arrange
            var employees = new[] { new Employee() };
            var employeeDtos = new[] { new EmployeeDto() };

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);
            _mockMapper.Setup(m => m.Map<EmployeeDto[]>(employees)).Returns(employeeDtos);

            // Act
            var result = await _employeeService.GetAllAsync();

            // Assert
            Assert.AreEqual(employeeDtos, result);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsMappedEmployeeDto()
        {
            // Arrange
            var employee = new Employee();
            var employeeDto = new EmployeeDto();

            _mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);
            _mockMapper.Setup(m => m.Map<EmployeeDto>(employee)).Returns(employeeDto);

            // Act
            var result = await _employeeService.GetByIdAsync(1);

            // Assert
            Assert.AreEqual(employeeDto, result);
        }

        [TestMethod]
        public async Task GetListByNameAsync_ReturnsFilteredAndMappedEmployeeDtos()
        {
            // Arrange
            var employees = new[]
            {
                new Employee { employee_name = "Andy Orozco" },
                new Employee { employee_name = "Richard Villarreal" }
            };

            var employeeDtos = new[]
            {
                new EmployeeDto { Name = "Andy Orozco" }
            };

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);
            _mockMapper.Setup(m => m.Map<EmployeeDto[]>(It.Is<Employee[]>(e => e.Length == 1 && e[0].employee_name == "Andy Orozco"))).Returns(employeeDtos);

            // Act
            var result = await _employeeService.GetListByNameAsync("Or");

            // Assert
            Assert.AreEqual(employeeDtos, result);
        }

        [TestMethod]
        public async Task GetListByNameAsync_ReturnsEmptyArrayWhenNoMatches()
        {
            // Arrange
            var employees = new[]
            {
                new Employee { employee_name = "Andy Orozco" },
                new Employee { employee_name = "Richard Villarreal" }
            };

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);

            // Act
            var result = await _employeeService.GetListByNameAsync("Charlie");

            // Assert
            Assert.AreEqual(0, result.Length);
        }
    }
}