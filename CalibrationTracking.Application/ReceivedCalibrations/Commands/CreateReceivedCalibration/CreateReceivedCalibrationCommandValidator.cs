using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Application.ReceivedCalibrations.Commands.CreateReceivedCalibration;

namespace CalibrationTracking.Application.ReceivedCalibrations.Commands.CreateReceivedCalibration
{
    public class CreateReceivedCalibrationCommandValidator : AbstractValidator<CreateReceivedCalibrationCommand>
    {
        public CreateReceivedCalibrationCommandValidator()
        {
        }
    }
}
