using FluentValidation;

namespace CalibrationTracking.Application.Calibrations.Commands.UpdateCalibration
{
    public class UpdateCalibrationCommandValidator : AbstractValidator<UpdateCalibrationCommand>
    {
        public UpdateCalibrationCommandValidator()
        {
        }
    }
}
