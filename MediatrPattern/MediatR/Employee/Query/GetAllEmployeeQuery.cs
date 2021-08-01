using System.Collections.Generic;
using MediatR;

namespace MediatrPattern.MediatR.Employee.Query
{
    public class GetAllEmployeeQuery : IRequest<List<Entities.Employee>>
    {
    }
}