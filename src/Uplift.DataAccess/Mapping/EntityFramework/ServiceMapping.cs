using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;
using Uplift.Models.ValueObjects;

namespace Uplift.DataAccess.Mapping
{
    public class ServiceMapping : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.Name)
              .Property(p => p.name)
              .HasMaxLength(255)
              .HasColumnName("Name");

            builder.Property(x => x.LongDesc)
                .HasMaxLength(1000);

            builder.ToTable("Services");
        }
    }
}
