using MediatR;
using MediatrPattern.Dto;

namespace MediatrPattern.MediatR.Employee.Command
{
    public class UpdateEmployeeCommand : IRequest
    {
        public UpdateEmployeeCommand(Entities.Employee employee, EmployeeDto dto)
        {
            Employee = employee;
            Dto = dto;
        }

        public Entities.Employee Employee { get; }
        public EmployeeDto Dto { get; }
    }
}