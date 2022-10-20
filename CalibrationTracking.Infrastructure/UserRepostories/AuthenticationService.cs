using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;

namespace CalibrationTracking.Infrastructure.UserRepostories
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> AuthenticateAsync(string userName, string password)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            return await Task.FromResult(true);
        }
    }
}