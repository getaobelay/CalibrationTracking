using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Application.Departments.Queries.GetAllDepartments;

namespace CalibrationTracking.Application.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryValidator : AbstractValidator<GetAllDepartmentsQuery>
    {
        public GetAllDepartmentsQueryValidator()
        {
        }
    }
}
