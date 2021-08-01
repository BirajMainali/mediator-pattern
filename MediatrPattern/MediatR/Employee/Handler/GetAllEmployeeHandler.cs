using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrPattern.MediatR.Employee.Query;
using MediatrPattern.Repository.Interface;

namespace MediatrPattern.MediatR.Employee.Handler
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, List<Entities.Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Entities.Employee>> Handle(GetAllEmployeeQuery request,
            CancellationToken cancellationToken) 
            => await Task.Run(() => _employeeRepository.GetAllAsync(), cancellationToken);
    }
}