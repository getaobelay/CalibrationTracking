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

namespace CalibrationTracking.Application.Calibrations.Commands.CreateCalibration
{
    public class CreateCalibrationCommand : IRequest<Calibration>
    {
        public string CalibrationSKU { get; set; } = null!;
        public string? Employee { get; set; }
        public string? Device { get; set; }
        public string? Remarks { get; set; }
        public string? Frequency { get; set; }
        public string? Department { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public class CreateCalibrationCommandHandler : IRequestHandler<CreateCalibrationCommand, Calibration>
        {
            private readonly CalibrationDbContext _context;

            public CreateCalibrationCommandHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<Calibration> Handle(CreateCalibrationCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var calibration = new Calibration
                    {
                        CalibrationSKU = request.CalibrationSKU,
                        Device = request.Device,
                        Employee = request.Employee,
                        Frequency = request.Frequency,
                        Remarks = request.Remarks,
                        Department = request.Department,
                        Description = request.Description,
                        CreatedAt = DateTime.Now,
                    };

                    await _context.AddAsync(calibration);
                    await _context.SaveChangesAsync(cancellationToken);

                    return calibration;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
