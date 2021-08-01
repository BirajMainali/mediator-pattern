using System.Threading.Tasks;
using System.Transactions;
using MediatrPattern.Dto;
using MediatrPattern.Entities;
using MediatrPattern.Repository.Interface;
using MediatrPattern.Services.Interfaces;

namespace MediatrPattern.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Create(EmployeeDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var employee = new Employee(dto.FirstName, dto.LastName, dto.Address, dto.Phone, dto.Salary);
            await _employeeRepository.Create(employee);
            await _employeeRepository.Flush();
            tsc.Complete();
            return employee;
        }

        public async Task Update(Employee employee, EmployeeDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            employee.Update(dto.FirstName, dto.LastName, dto.Address, dto.Phone, dto.Salary);
            _employeeRepository.Update(employee);
            await _employeeRepository.Flush();
            tsc.Complete();
        }

        public async Task Remove(Employee employee)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            _employeeRepository.Remove(employee);
            await _employeeRepository.Flush();
            tsc.Complete();
        }
    }
}