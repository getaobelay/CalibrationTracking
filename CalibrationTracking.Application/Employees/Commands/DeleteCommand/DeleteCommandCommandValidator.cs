using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Application.Employees.Commands.DeleteCommand;

namespace CalibrationTracking.Application.Employees.Commands.DeleteCommand
{
    public class DeleteCommandCommandValidator : AbstractValidator<DeleteCommandCommand>
    {
        public DeleteCommandCommandValidator()
        {
        }
    }
}
