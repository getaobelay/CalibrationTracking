using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;

namespace CalibrationTracking.Infrastructure.UserRepostories
{
    public class UserService : IUserService
    {
        public Task<bool> CreateUserAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}