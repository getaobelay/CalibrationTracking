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
            Message = $"אנא וודא  שמספר המכשיר ({message}) תקין ";
        }


        public CalibrationNotFoundException(Guid? message)
        {
            Message = $"אנא וודא  שמספר המכשיר ({message}) תקין ";
        }

        public string? Message { get; }
    }
}
