using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationTracking.Application.Calibrations.Queries.GetSingleCalibration;
using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;

namespace CalibrationTracking.Application.Calibrations.Queries.GetSingleCalibration
{
    public class GetSingleCalibrationQueryValidator : AbstractValidator<GetSingleCalibrationQuery>
    {
        public GetSingleCalibrationQueryValidator()
        {
        }
    }
}
