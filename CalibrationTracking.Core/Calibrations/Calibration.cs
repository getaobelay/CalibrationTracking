using CalibrationTracking.Abstractions.Base;

namespace CalibrationTracking.Core.Calibrations
{
    public class Calibration : BaseEntity
    {

        public string CalibrationSKU { get; set; } = null!;
        public string? Employee { get; set; }
        public string? Department { get; set; }
        public string? Description { get; set; }
        public string? Device { get; set; }
        public string? Remarks { get; set; }
        public string? Frequency { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}