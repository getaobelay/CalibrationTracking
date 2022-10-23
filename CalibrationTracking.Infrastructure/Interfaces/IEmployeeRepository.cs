using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Core.Employees;
using CalibrationTracking.Infrastructure.Context;

namespace CalibrationTracking.Infrastructure.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="IBaseRepository&lt;Pulser.Core.Entities.CellAge, Pulser.Infrastructure.Context.PulserDbContext&gt;" />
    public interface IEmployeeRepository : IBaseRepository<Employee, CalibrationDbContext>
    {
    }
}