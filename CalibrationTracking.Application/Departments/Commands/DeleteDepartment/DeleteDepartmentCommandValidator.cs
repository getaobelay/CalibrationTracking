using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationTracking.Application.Departments.DeleteDepartment
{
    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator()
        {
        }
    }
}
