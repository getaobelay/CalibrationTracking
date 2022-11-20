using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CalibrationTracking.Application.OrderSkus.Commands.IncrementOrderSku;
using CalibrationTracking.Core.Calibrations;

namespace CalibrationTracking.Application.OrderSkus.Commands.IncrementOrderSku
{
	public class IncrementOrderSkuCommand : IRequest<bool>
	{
		public Guid CalibrationId { get; set; }

		public class IncrementOrderSkuCommandHandler : IRequestHandler<IncrementOrderSkuCommand, bool>
		{
			private readonly CalibrationDbContext _context;

			public IncrementOrderSkuCommandHandler(CalibrationDbContext context)
			{
				_context = context;
			}

			public async Task<bool> Handle(IncrementOrderSkuCommand request, CancellationToken cancellationToken)
			{
				try
				{
					var counter = await _context.OrderSku.FirstAsync();
					var calibration = await _context.Calibrations.SingleOrDefaultAsync(x=> x.Id == request.CalibrationId);

					counter.Counter++;

					var receivedCalibration = new ReceivedCalibration
					{
						CalibrationId = request.CalibrationId,
						CreatedAt = DateTime.Now,
						ModifiedAt = DateTime.Now,
					};


					_context.Update(counter);

					await _context.AddAsync(receivedCalibration);
					await _context.SaveChangesAsync();

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
