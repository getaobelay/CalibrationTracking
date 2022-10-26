using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Core.Employees;
using CalibrationTracking.Application.Employees.Commands.CreateEmployee;

namespace CalibrationTracking.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public Guid DepartmentId { get; set; }

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
        {
            private readonly CalibrationDbContext _context;

            public CreateEmployeeCommandHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = new Employee
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    DepartmentId = request.DepartmentId,

                };


                await _context.AddAsync(employee);

                await _context.SaveChangesAsync();

                return employee;
            }
        }
    }
}
