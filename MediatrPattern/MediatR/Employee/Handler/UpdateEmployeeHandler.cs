using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrPattern.MediatR.Employee.Command;
using MediatrPattern.Services.Interfaces;

namespace MediatrPattern.MediatR.Employee.Handler
{
    public class UpdateEmployeeHandler : AsyncRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeService _employeeService;

        public UpdateEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        protected override async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken) 
            => await _employeeService.Update(request.Employee, request.Dto);
    }
}