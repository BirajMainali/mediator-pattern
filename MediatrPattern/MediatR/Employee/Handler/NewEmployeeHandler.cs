using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrPattern.Dto;
using MediatrPattern.MediatR.Employee.Command;
using MediatrPattern.Repository.Interface;
using MediatrPattern.Services.Interfaces;

namespace MediatrPattern.MediatR.Employee.Handler
{
    public class NewEmployeeHandler : IRequestHandler<NewEmployeeCommand, Entities.Employee>
    {
        private readonly IEmployeeService _employeeService;

        public NewEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<Entities.Employee> Handle(NewEmployeeCommand request, CancellationToken cancellationToken) 
            => await _employeeService.Create(request.EmployeeDto);
    }
}