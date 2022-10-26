using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Core.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalibrationTracking.Infrastructure.Context.Configurations
{
    public class CalibrationConfig : IEntityTypeConfiguration<Calibration>
    {
        public void Configure(EntityTypeBuilder<Calibration> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}