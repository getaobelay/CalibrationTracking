using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Infrastructure.Context;

namespace CalibrationTracking.Application.Calibrations.Queries.IsCalibrationExists
{
	public class IsCalibrationExistsQuery : IRequest<bool>
	{
		public string? CalibrationSku { get; set; }

		public class IsCalibrationExistsQueryHandler : IRequestHandler<IsCalibrationExistsQuery, bool>
		{
			private readonly CalibrationDbContext _context;

			public IsCalibrationExistsQueryHandler(CalibrationDbContext context)
			{
				_context = context;
			}
			public async Task<bool> Handle(IsCalibrationExistsQuery request, CancellationToken cancellationToken)
			{
				return _context.Calibrations.Any(x => x.CalibrationSKU == request.CalibrationSku);
			}
		}
	}
}
