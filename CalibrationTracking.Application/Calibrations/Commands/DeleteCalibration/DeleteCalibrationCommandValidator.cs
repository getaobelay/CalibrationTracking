using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationTracking.Application.Calibrations.Commands.DeleteCalibration
{
    public class DeleteCalibrationCommandValidator : AbstractValidator<DeleteCalibrationCommand>
    {
        public DeleteCalibrationCommandValidator()
        {
        }
    }
}
