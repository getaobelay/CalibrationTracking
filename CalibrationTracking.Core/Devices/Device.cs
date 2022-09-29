using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Core.Devices.Enumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationTracking.Core.Devices
{
    public class Device : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Serial { get; set; } = null!;


        public DateTime LastCalibrationDate { get; set; }
        public DateTime NextCalibrationDate { get; set; }

        public DeviceStatus Status { get; set; }

    }
}
