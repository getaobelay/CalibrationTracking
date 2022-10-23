using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Core.Employees;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Infrastructure.Interfaces;

namespace CalibrationTracking.Infrastructure.Repositories
{
    internal class EmployeeRepository : BaseRepository<Employee, CalibrationDbContext>, IEmployeeRepository
    {
        private readonly CalibrationDbContext _context;

        public EmployeeRepository(CalibrationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}