using MediatR;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Core.Departments;
using CalibrationTracking.Application.Departments.Commands.CreateDepartment;

namespace CalibrationTracking.Application.Departments.Commands.CreateDepartment
{
	public class CreateDepartmentCommand : IRequest<Department>
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;


		public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Department>
		{
			private readonly CalibrationDbContext _context;

			public CreateDepartmentCommandHandler(CalibrationDbContext context)
			{
				_context = context;
			}

			public async Task<Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
			{
				try
				{
					var department = new Department
					{
						Name = request.Name,
						Description = request.Description,

					};


					await _context.AddAsync(department);

					await _context.SaveChangesAsync();

					return department;
				}
				catch (Exception)
				{

					throw;
				}
			}
		}
	}
}
