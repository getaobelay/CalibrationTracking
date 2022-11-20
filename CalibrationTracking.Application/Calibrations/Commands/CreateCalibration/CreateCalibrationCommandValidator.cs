﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Application.ReceivedCalibrations.Commands.CreateReceivedCalibration;

namespace CalibrationTracking.Application.Calibrations.Commands.CreateCalibration
{
    public class CreateCalibrationCommandValidator : AbstractValidator<CreateCalibrationCommand>
    {
        public CreateCalibrationCommandValidator()
        {
        }
    }
}
