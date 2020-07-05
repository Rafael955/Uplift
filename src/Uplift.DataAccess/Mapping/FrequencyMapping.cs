using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;

namespace Uplift.DataAccess.Mapping
{
    public class FrequencyMapping : IEntityTypeConfiguration<Frequency>
    {
        public void Configure(EntityTypeBuilder<Frequency> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(255);

            builder.ToTable("Frequencies");
        }
    }
}
