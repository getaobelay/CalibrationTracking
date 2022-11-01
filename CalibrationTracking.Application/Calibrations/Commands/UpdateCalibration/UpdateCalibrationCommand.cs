using MediatR;
using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Application.Calibrations.Commands.CreateCalibration;
using Microsoft.EntityFrameworkCore;

namespace CalibrationTracking.Application.Calibrations.Commands.UpdateCalibration
{
    public class UpdateCalibrationCommand : IRequest<Calibration>
    {
        public Guid CalibrationId { get; set; }

        public string CalibrationSKU { get; set; } = null!;
        public string? Employee { get; set; }
        public string? Device { get; set; }
        public string? Remarks { get; set; }
        public string? Frequency { get; set; }
        public string? Department { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public class UpdateCalibrationCommandHandler : IRequestHandler<UpdateCalibrationCommand, Calibration>
        {
            private readonly CalibrationDbContext _context;

            public UpdateCalibrationCommandHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<Calibration> Handle(UpdateCalibrationCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var exists = await _context.Calibrations.SingleOrDefaultAsync(x => x.Id == request.CalibrationId);

                    exists.Device = request.Device;
                    exists.Employee = request.Employee;
                    exists.Frequency = request.Frequency;
                    exists.Remarks = request.Remarks;
                    exists.Department = request.Department;
                    exists.Description = request.Description;
                    exists.CreatedAt = DateTime.Now;


                    _context.Update(exists);

                    await _context.SaveChangesAsync(cancellationToken);

                    return exists;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
