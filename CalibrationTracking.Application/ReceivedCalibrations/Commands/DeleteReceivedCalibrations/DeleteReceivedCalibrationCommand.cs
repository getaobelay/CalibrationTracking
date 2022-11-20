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
using CalibrationTracking.Application.Calibrations.Exceptions;
using CalibrationTracking.Application.ReceivedCalibrations.Commands.DeleteReceivedCalibrations;

namespace CalibrationTracking.Application.ReceivedCalibrations.Commands.DeleteReceivedCalibrations
{
    public class DeleteReceivedCalibrationCommand : IRequest<bool>
    {
        public Guid ReceivedCalibrationId { get; set; }

        public class DeleteReceivedCalibrationCommandHandler : IRequestHandler<DeleteReceivedCalibrationCommand, bool>
        {
            private readonly CalibrationDbContext _context;

            public DeleteReceivedCalibrationCommandHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(DeleteReceivedCalibrationCommand request, CancellationToken cancellationToken)
            {
                var calibration = await _context.ReceivedCalibrations.SingleOrDefaultAsync(x => x.Id == request.ReceivedCalibrationId);

                if (calibration == null) throw new CalibrationNotFoundException(request.ReceivedCalibrationId);

                _context.Remove(calibration);

                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}
