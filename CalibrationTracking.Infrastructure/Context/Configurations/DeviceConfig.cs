using CalibrationTracking.Core.Devices;
using CalibrationTracking.Core.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalibrationTracking.Infrastructure.Context.Configurations
{
    public class DeviceConfig : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}