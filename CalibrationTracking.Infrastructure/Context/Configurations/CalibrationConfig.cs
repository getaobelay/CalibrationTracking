﻿using CalibrationTracking.Core.Calibrations;
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