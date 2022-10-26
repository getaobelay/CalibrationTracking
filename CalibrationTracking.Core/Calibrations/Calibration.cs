using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Core.Departments;
using CalibrationTracking.Core.Devices;
using CalibrationTracking.Core.Employees;

namespace CalibrationTracking.Core.Calibrations
{
    public class Calibration : BaseEntity
    {

        public string CalibrationSKU { get; set; } = null!;
        public Employee? Employee { get; set; }
        public Device? Device { get; set; }
        public string? Remarks { get; set; }
        public string? Frequency { get; set; }
        public DateTime CreatedAt { get; set; }
      

    }
}