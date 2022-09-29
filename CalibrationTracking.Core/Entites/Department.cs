using CalibrationTracking.Abstractions.Base;

namespace CalibrationTracking.Core.Entites
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>(); 
    }
}
