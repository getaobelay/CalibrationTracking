using CalibrationTracking.Core;
using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Core.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalibrationTracking.Infrastructure.Context.Configurations
{
    public class OrderSkuConfig : IEntityTypeConfiguration<OrderSku>
    {
        public void Configure(EntityTypeBuilder<OrderSku> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}