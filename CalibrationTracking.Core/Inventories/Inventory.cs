using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Core.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationTracking.Core.Inventories
{
    public class Inventory : BaseEntity
    {
        public int InventorySKU { get; set; }
    }
}
