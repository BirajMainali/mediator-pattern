using System.Threading.Tasks;
using MediatrPattern.Dto;
using MediatrPattern.Entities;
using MediatrPattern.Repository.Interface;
using MediatrPattern.Services;
using Moq;
using Xunit;

namespace XTest
{
    public class EmployeeServiceTest
    {
        private readonly EmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository = Mock.Of<IEmployeeRepository>();

        public EmployeeServiceTest()
        {
            _employeeService = new EmployeeService(_employeeRepository);
        }

        [Fact]
        public async Task test_create_creates_employee()
        {
            var dto = GetDto();
            await _employeeService.Create(dto);
            Mock.Get(_employeeRepository).Verify(x => x.Create(It.Is<Employee>(y
                => y.FirstName == dto.FirstName &&
                   y.LastName == dto.LastName &&
                   y.Address == dto.Address &&
                   y.Phone == dto.Phone &&
                   y.Salary == dto.Salary)));
        }

        [Fact]
        public async Task test_update_updates_employee()
        {
            var dto = GetDto();
            var employee = new Employee("Biraj", "Mainali", "Kathmandu", "934839483", 200000);
            await _employeeService.Update(employee, dto);
            Mock.Get(_employeeRepository).Verify(x => x.Update(It.Is<Employee>(y
                => y.FirstName == dto.FirstName &&
                   y.LastName == dto.LastName &&
                   y.Address == dto.Address &&
                   y.Phone == dto.Phone &&
                   y.Salary == dto.Salary)));
        }

        [Fact]
        public async Task test_remove_removes_employee()
        {
            var employee = new Employee("Biraj", "Mainali", "Kathmandu", "934839483", 200000);
            await _employeeService.Remove(employee);
            Mock.Get(_employeeRepository).Verify(x => x.Remove(employee));
        }
        
        private static EmployeeDto GetDto()
        {
            const string firstName = "XBiraj";
            const string lastName = "XMainali";
            const string address = "Jhapa";
            const string phone = "988033439";
            const decimal salary = 20000M;
            return new EmployeeDto(firstName, lastName, address, phone, salary);
        }
    }
}
