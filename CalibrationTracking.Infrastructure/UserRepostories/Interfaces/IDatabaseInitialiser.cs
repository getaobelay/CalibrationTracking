namespace CalibrationTracking.Infrastructure.UserRepostories.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task InitialiseAsync();

        Task SeedAsync();

        Task TrySeedAsync();
    }
}