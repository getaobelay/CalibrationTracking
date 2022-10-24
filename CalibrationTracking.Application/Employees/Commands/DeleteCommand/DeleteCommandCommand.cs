using MediatR;
using CalibrationTracking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CalibrationTracking.Application.Employees.Commands.DeleteCommand
{
    public class DeleteCommandCommand : IRequest<bool>
    {
        public Guid EmployeeId { get; set; }

        public class DeleteCommandCommandHandler : IRequestHandler<DeleteCommandCommand, bool>
        {

            private readonly CalibrationDbContext _context;

            public DeleteCommandCommandHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(DeleteCommandCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var employee = _context.Employees.SingleOrDefaultAsync(x => x.Id == request.EmployeeId);

                    if (employee is null)
                        throw new ArgumentNullException(nameof(employee));

                    _context.Remove(employee);

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
