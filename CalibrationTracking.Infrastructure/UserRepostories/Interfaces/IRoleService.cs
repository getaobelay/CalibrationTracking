namespace CalibrationTracking.Infrastructure.UserRepostories.Interfaces
{
    public interface IRoleService
    {
        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> IsRoleExistsAsync(string roleName);
    }
}