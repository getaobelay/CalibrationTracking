using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Application.Employees.Queries.GetAllEmployees;
using CalibrationTracking.Core.Employees;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Core.Calibrations;
using Microsoft.EntityFrameworkCore;

namespace CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations
{
    public class GetAllCalibrationsQuery : IRequest<List<Calibration>>
    {
        public class GetAllCalibrationsQueryHandler : IRequestHandler<GetAllCalibrationsQuery, List<Calibration>>
        {
            private readonly CalibrationDbContext _context;

            public GetAllCalibrationsQueryHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Calibration>> Handle(GetAllCalibrationsQuery request, CancellationToken cancellationToken)
            {
                return await _context.Calibrations.ToListAsync();
            }
        }


    }
}
