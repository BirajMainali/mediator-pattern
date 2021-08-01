using System.Threading.Tasks;
using MediatrPattern.Dto;
using MediatrPattern.Entities;

namespace MediatrPattern.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> Create(EmployeeDto dto);
        Task Update(Employee employee, EmployeeDto dto);
        Task Remove(Employee employee);
    }
}