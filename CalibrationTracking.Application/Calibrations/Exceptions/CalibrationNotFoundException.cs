using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;
namespace CalibrationTracking.Application.Calibrations.Exceptions
{
    public class CalibrationNotFoundException : Exception
    {
        public CalibrationNotFoundException()
        {
        }

        public CalibrationNotFoundException(string? message) : base(message)
        {
            Message = $"לא קיים מכשיר אם המקט {message} במערכת.";
        }


        public CalibrationNotFoundException(Guid? message)
        {
            Message = $"לא קיים מכשיר אם המקט {message} במערכת.";
        }

        public string? Message { get; }
    }
}
