using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Core.Departments;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Infrastructure.Interfaces;

namespace CalibrationTracking.Infrastructure.Repositories
{
    internal class DepartmentRepository : BaseRepository<Department, CalibrationDbContext>, IDepartmentRepository
    {
        private readonly CalibrationDbContext _context;

        public DepartmentRepository(CalibrationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}