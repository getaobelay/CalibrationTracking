using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Core.Departments;
using CalibrationTracking.Infrastructure.Context;

namespace CalibrationTracking.Infrastructure.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department, CalibrationDbContext>
    {
    }
}