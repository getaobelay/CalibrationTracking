using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Application.ReceivedCalibrations.Commands.DeleteReceivedCalibrations;

namespace CalibrationTracking.Application.ReceivedCalibrations.Commands.DeleteReceivedCalibrations
{
    public class DeleteReceivedCalibrationCommandValidator : AbstractValidator<DeleteReceivedCalibrationCommand>
    {
        public DeleteReceivedCalibrationCommandValidator()
        {
        }
    }
}
