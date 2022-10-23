using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationTracking.Application.Employees.EditEmployee
{
    public class EditEmployeeCommandValidator : AbstractValidator<EditEmployeeCommand>
    {
        public EditEmployeeCommandValidator()
        {
        }
    }
}
