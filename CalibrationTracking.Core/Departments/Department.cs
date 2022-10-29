using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Core.Employees;

namespace CalibrationTracking.Core.Departments
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();


        public override bool Equals(object other)
        {
            return Equals(other! as Department);
        }

        public virtual bool Equals(Department other)
        {
            if (other == null) { return false; }
            if (object.ReferenceEquals(this, other)) { return true; }
            return this.Id == other.Id;
        }

       
        public static bool operator ==(Department item1, Department item2)
        {
            if (object.ReferenceEquals(item1, item2)) { return true; }
            if ((object)item1 == null || (object)item2 == null) { return false; }
            return item1.Id == item2.Id;
        }

        public static bool operator !=(Department item1, Department item2)
        {
            return !(item1 == item2);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}