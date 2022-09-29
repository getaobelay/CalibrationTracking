using CalibrationTracking.Abstractions.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalibrationTracking.Core.Entites
{
   
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }


}
