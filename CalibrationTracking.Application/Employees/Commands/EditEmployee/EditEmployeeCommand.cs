using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Application.Employees.Commands.EditEmployee;

namespace CalibrationTracking.Application.Employees.Commands.EditEmployee
{
    public class EditEmployeeCommand : IRequest
    {
        public class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand>
        {
            public EditEmployeeCommandHandler()
            {
            }

            public async Task<Unit> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
            {
				throw new NotImplementedException();
            }
        }
    }
}
