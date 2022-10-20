using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;

namespace CalibrationTracking.Infrastructure.UserRepostories
{
    public class RoleService : IRoleService
    {
        private readonly CalibrationDbContext _context;

        public RoleService(CalibrationDbContext applicationDb)
        {
            _context = applicationDb;
        }

        public Task<bool> IsInRoleAsync(string userId, string role)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsRoleExistsAsync(string roleName)
        {
            return true;
            //return await Task.FromResult(_context.Roles.Any(x => x.Name == roleName));
        }
    }
}