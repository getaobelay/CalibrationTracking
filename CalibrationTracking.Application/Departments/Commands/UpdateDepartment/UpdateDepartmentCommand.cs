using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Core.Departments;
using Microsoft.EntityFrameworkCore;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Application.Departments.Commands.UpdateDepartment;

namespace CalibrationTracking.Application.Departments.Commands.UpdateDepartment
{
	public class UpdateDepartmentCommand : IRequest<Department>
	{
		public Guid DepartmentId { get; set; }

		public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Department>
		{
			private readonly CalibrationDbContext _context;
			public UpdateDepartmentCommandHandler(CalibrationDbContext context)
			{
				_context = context;
			}

			public async Task<Department> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
			{
				try
				{
					var exists = await _context.Departments.SingleOrDefaultAsync(x => x.Id == request.DepartmentId);

					if (exists == null) throw new ArgumentNullException(nameof(Department));
				
				   _context.Update(exists);

					await _context.SaveChangesAsync();

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
