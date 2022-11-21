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
using CalibrationTracking.Application.ReceivedCalibrations.Commands.CreateReceivedCalibration;
using CalibrationTracking.Core.ReceivedCalibration;

namespace CalibrationTracking.Application.ReceivedCalibrations.Commands.CreateReceivedCalibration
{
    public class CreateReceivedCalibrationCommand : IRequest<bool>
    {
        public Guid CalibrationId { get; set; }

        public class CreateReceivedCalibrationCommandHandler : IRequestHandler<CreateReceivedCalibrationCommand, bool>
        {
            private readonly CalibrationDbContext _context;

            public CreateReceivedCalibrationCommandHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(CreateReceivedCalibrationCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var calibration = new ReceivedCalibration
                    {
                        CalibrationId = request.CalibrationId,                  
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                    };

                    await _context.AddAsync(calibration);
                    await _context.SaveChangesAsync(cancellationToken);

                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
          
            }
        }
    }
}
