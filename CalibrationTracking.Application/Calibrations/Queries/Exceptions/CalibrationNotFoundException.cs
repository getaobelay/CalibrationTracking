using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;
namespace CalibrationTracking.Application.Calibrations.Queries.Exceptions
{
    public class CalibrationNotFoundException : Exception
    {
        public CalibrationNotFoundException()
        {
        }

        public CalibrationNotFoundException(string? message) : base(message)
        {
            Message = $"מכשיר מספר {message} לא נמצא במערכת";
        }


        public CalibrationNotFoundException(Guid? message)
        {
            Message = $"מכשיר מספר {message} לא נמצא במערכת";
        }

        public string? Message { get; }
    }
}
