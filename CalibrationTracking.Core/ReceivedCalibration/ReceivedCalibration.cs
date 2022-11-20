using CalibrationTracking.Abstractions.Base;

namespace CalibrationTracking.Core.Calibrations
{
    public class ReceivedCalibration : BaseEntity
    {


        public Guid CalibrationId {get; set; }
        public Calibration Calibration { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }



    }
}