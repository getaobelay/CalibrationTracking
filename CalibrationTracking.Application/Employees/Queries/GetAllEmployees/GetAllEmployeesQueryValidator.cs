using FluentValidation;
using CalibrationTracking.Application.Employees.Queries.GetAllEmployees;

namespace CalibrationTracking.Application.Employees.Queries.GetAllDepartments
{
    public class GetAllEmployeesQueryValidator : AbstractValidator<GetAllEmployeesQuery>
    {
        public GetAllEmployeesQueryValidator()
        {
        }
    }
}
