﻿using MediatR;
using CalibrationTracking.Core.Departments;
using CalibrationTracking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CalibrationTracking.Application.Employees.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQuery : IRequest<List<Department>>
    {
        public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<Department>>
        {
            private readonly CalibrationDbContext _context;

            public GetAllDepartmentsQueryHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Department>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
            {
                return await _context.Departments.ToListAsync();
            }
        }
    }
}