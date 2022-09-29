namespace CalibrationTracking.Abstractions.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface IDatabaseInitialiser
    {
        /// <summary>
        /// Initialises the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task InitialiseAsync();

        /// <summary>
        /// Seeds the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task SeedAsync();

        /// <summary>
        /// Tries the seed asynchronous.
        /// </summary>
        /// <returns></returns>
        Task TrySeedAsync();
    }
}
