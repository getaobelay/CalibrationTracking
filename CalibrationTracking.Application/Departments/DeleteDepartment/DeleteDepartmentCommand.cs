using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Application.Departments.UpdateDepartment;
using CalibrationTracking.Core.Departments;
using CalibrationTracking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CalibrationTracking.Application.Departments.DeleteDepartment
{
	public class DeleteDepartmentCommand : IRequest<bool>
	{
		public Guid DepartmentId { get; set; }

		public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
		{
			private readonly CalibrationDbContext _context;
			public DeleteDepartmentCommandHandler(CalibrationDbContext context)
			{
				_context = context;
			}

			public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
			{
				try
				{
					var exists = await _context.Departments.SingleOrDefaultAsync(x => x.Id == request.DepartmentId);

					if (exists == null) throw new ArgumentNullException(nameof(Department));

					_context.Remove(exists);

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
