using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations
{
    public class GetAllCalibrationsQueryValidator : AbstractValidator<GetAllCalibrationsQuery>
    {
        public GetAllCalibrationsQueryValidator()
        {
        }
    }
}
