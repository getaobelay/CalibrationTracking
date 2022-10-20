using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Core.Devices;

namespace CalibrationTracking.Core.Inventories
{
    public class Inventory : BaseEntity
    {
        public int InventorySKU { get; set; }
        public Guid DeviceId { get; set; }
        public Device Device { get; set; } = null!;
    }
}