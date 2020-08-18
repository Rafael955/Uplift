using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;

namespace Uplift.DataAccess.Mapping
{
    public class ApplicationUserMapping : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.OwnsOne(p => p.Name)
             .Property(p => p.name)
             .HasColumnName("Name")
             .HasMaxLength(255);

            builder.Property(x => x.StreetAddress)
               .HasMaxLength(500);

            builder.Property(x => x.City)
                .HasMaxLength(255);

            builder.Property(x => x.State)
                .HasMaxLength(255);

            builder.Property(x => x.PostalCode)
                .HasMaxLength(15);
        }
    }
}
