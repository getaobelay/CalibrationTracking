using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Application.Employees.Commands.EditEmployee;

namespace CalibrationTracking.Application.Employees.Commands.EditEmployee
{
    public class EditEmployeeCommandValidator : AbstractValidator<EditEmployeeCommand>
    {
        public EditEmployeeCommandValidator()
        {
        }
    }
}
