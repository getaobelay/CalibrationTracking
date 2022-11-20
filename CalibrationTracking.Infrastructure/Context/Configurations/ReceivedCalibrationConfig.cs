using CalibrationTracking.Core.Calibrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalibrationTracking.Infrastructure.Context.Configurations
{
    public class ReceivedCalibrationConfig : IEntityTypeConfiguration<ReceivedCalibration>
    {
        public void Configure(EntityTypeBuilder<ReceivedCalibration> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}