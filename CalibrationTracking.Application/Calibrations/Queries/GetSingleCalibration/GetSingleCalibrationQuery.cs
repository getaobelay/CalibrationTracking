using MediatR;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Core.Calibrations;
using Microsoft.EntityFrameworkCore;

namespace CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations
{
    public class GetSingleCalibrationQuery : IRequest<Calibration>
    {
        public Guid CalibrationId { get; set; }

        public class GetSingleCalibrationQueryHandler : IRequestHandler<GetSingleCalibrationQuery, Calibration>
        {
            private readonly CalibrationDbContext _context;

            public GetSingleCalibrationQueryHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<Calibration> Handle(GetSingleCalibrationQuery request, CancellationToken cancellationToken)
            {
                var calibration = await _context.Calibrations.SingleOrDefaultAsync(x => x.Id == request.CalibrationId);

                if(calibration == null) throw new ArgumentNullException(nameof(Calibration));

                return calibration;
            }
        }


    }
}
