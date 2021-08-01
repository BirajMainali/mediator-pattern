using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrPattern.MediatR.Employee.Query;
using MediatrPattern.Repository.Interface;

namespace MediatrPattern.MediatR.Employee.Handler
{
    public class GetSingleEmployeeHandler : IRequestHandler<GetSingleEmployeeQuery, Entities.Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetSingleEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Entities.Employee> Handle(GetSingleEmployeeQuery request, CancellationToken cancellationToken) 
            => await Task.Run(() => _employeeRepository.FindOrThrow(request.Id), cancellationToken);
    }
}