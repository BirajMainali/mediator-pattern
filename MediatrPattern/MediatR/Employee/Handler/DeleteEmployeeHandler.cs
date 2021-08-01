using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrPattern.MediatR.Employee.Command;
using MediatrPattern.Services.Interfaces;

namespace MediatrPattern.MediatR.Employee.Handler
{
    public class DeleteEmployeeHandler : AsyncRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeService _employeeService;

        public DeleteEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        protected override async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken) 
            => await _employeeService.Remove(request.Employee);
    }
}