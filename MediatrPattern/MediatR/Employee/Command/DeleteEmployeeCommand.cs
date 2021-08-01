using MediatR;

namespace MediatrPattern.MediatR.Employee.Command
{
    public class DeleteEmployeeCommand : IRequest
    {
        public DeleteEmployeeCommand(Entities.Employee employee) 
            => Employee = employee;

        public Entities.Employee Employee { get; }
    }
}