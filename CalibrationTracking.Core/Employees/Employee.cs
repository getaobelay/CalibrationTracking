using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Core.Departments;

namespace CalibrationTracking.Core.Employees
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }
}