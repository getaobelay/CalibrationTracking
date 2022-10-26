using MediatR;
using CalibrationTracking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CalibrationTracking.Core.Employees;

namespace CalibrationTracking.Application.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<List<Employee>>
    {
        public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
        {
            private readonly CalibrationDbContext _context;

            public GetAllEmployeesQueryHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            {
                return await _context.Employees.ToListAsync();
            }
        }
    }
}
