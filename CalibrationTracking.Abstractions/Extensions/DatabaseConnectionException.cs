namespace CalibrationTracking.Abstractions.Extensions
{
    [Serializable]
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string? message) : base(message)
        {
        }
    }
}