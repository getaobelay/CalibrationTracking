using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Core.Devices;
using CalibrationTracking.Core.Employees;
using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CalibrationTracking.Application.Calibrations.Queries.Exceptions;

namespace CalibrationTracking.Application.Calibrations.Commands.DeleteCalibration
{
    public class DeleteCalibrationCommand : IRequest<bool>
    {
        public Guid CalibrationId { get; set; }
        public string CalibrationSku { get; set; }

        public class DeleteCalibrationCommandHandler : IRequestHandler<DeleteCalibrationCommand, bool>
        {
            private readonly CalibrationDbContext _context;

            public DeleteCalibrationCommandHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(DeleteCalibrationCommand request, CancellationToken cancellationToken)
            {
                var calibration = await _context.Calibrations.SingleOrDefaultAsync(x => x.Id == request.CalibrationId);

                if (calibration == null) throw new CalibrationNotFoundException(request.CalibrationSku);

                _context.Remove(calibration);

                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}
