using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;
using Uplift.Models.ValueObjects;

namespace Uplift.DataAccess.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(a => a.Id);

            builder.OwnsOne(p => p.Name)
               .Property(p => p.name)
               .HasColumnName("Name")
               .HasMaxLength(255);

            builder.ToTable("Categories");
        }
    }
}
