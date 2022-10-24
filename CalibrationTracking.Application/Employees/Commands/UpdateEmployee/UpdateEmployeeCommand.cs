using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Core.Employees;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Application.Employees.Commands.CreateEmployee;
using CalibrationTracking.Application.Employees.Commands.UpdateEmployee;

namespace CalibrationTracking.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<Employee>
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
        {
            private readonly CalibrationDbContext _context;

            public UpdateEmployeeCommandHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = new Employee
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };


                await _context.AddAsync(employee);

                await _context.SaveChangesAsync();

                return employee;
            }

        }
    }
}
