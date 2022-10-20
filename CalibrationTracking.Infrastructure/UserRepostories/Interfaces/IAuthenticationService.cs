namespace CalibrationTracking.Infrastructure.UserRepostories.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<bool> AuthenticateAsync(string userName, string password);
    }
}