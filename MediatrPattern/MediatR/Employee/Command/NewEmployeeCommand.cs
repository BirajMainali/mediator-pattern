using MediatR;
using MediatrPattern.Dto;

namespace MediatrPattern.MediatR.Employee.Command
{
    public class NewEmployeeCommand : IRequest<Entities.Employee>
    {
        public NewEmployeeCommand(EmployeeDto employeeDto) 
            => EmployeeDto = employeeDto;

        public EmployeeDto EmployeeDto { get; }
    }
}