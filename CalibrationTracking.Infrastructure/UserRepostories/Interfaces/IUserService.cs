namespace CalibrationTracking.Infrastructure.UserRepostories.Interfaces
{
    public interface IUserService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<bool> CreateUserAsync(string userName, string password);

        Task<bool> DeleteUserAsync(string userId);
    }
}