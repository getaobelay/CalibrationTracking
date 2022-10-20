using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Core.Employees;

namespace CalibrationTracking.Core.Departments
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}