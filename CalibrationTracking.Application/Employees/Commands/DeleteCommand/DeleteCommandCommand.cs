using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Application.Employees.Commands.DeleteCommand;

namespace CalibrationTracking.Application.Employees.Commands.DeleteCommand
{
    public class DeleteCommandCommand : IRequest
    {
        public class DeleteCommandCommandHandler : IRequestHandler<DeleteCommandCommand>
        {
            public DeleteCommandCommandHandler()
            {
            }

            public async Task<Unit> Handle(DeleteCommandCommand request, CancellationToken cancellationToken)
            {
				throw new NotImplementedException();
            }
        }
    }
}
