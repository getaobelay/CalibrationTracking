using MediatR;

namespace CalibrationTracking.Application.Departments.Queries.GetDepartmentById
{
	public class GetDepartmentByIdCommand : IRequest
	{
		public class GetDepartmentByIdCommandHandler : IRequestHandler<GetDepartmentByIdCommand>
		{
			public GetDepartmentByIdCommandHandler()
			{
			}

			public async Task<Unit> Handle(GetDepartmentByIdCommand request, CancellationToken cancellationToken)
			{
				throw new NotImplementedException();
			}
		}
	}
}
