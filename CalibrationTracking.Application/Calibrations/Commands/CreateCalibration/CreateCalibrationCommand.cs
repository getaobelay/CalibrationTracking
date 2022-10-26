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
		public Guid? EmployeeId { get; set; }
		public Guid? DeviceId { get; set; }
		public string? Remarks { get; set; }
		public string? Frequency { get; set; }

		public class CreateCalibrationCommandHandler : IRequestHandler<CreateCalibrationCommand, Calibration>
		{
			private readonly CalibrationDbContext _context;

			public CreateCalibrationCommandHandler(CalibrationDbContext context)
			{
				_context = context;
			}

			public async Task<Calibration> Handle(CreateCalibrationCommand request, CancellationToken cancellationToken)
			{
				var device = await _context.Devices.SingleOrDefaultAsync(x => x.Id == request.DeviceId);

				if (device == null) throw new ArgumentNullException(nameof(Device));

				var employee = await _context.Employees.SingleOrDefaultAsync(x => x.Id == request.EmployeeId);

				if (employee == null) throw new ArgumentNullException(nameof(Employee));


				var calibration = new Calibration
				{
					CalibrationSKU = request.CalibrationSKU,
					Device = device,
					Employee = employee,
					Frequency = request.Frequency,
					Remarks = request.Remarks,
				};

				await _context.AddAsync(calibration);
				await _context.SaveChangesAsync(cancellationToken);

				return calibration;
			}
		}
	}
}
