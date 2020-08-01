using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;
using Uplift.Models.ValueObjects;

namespace Uplift.DataAccess.Mapping
{
    public class OrderDetailsMapping : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.ServiceName)
              .Property(p => p.name)
              .HasColumnName("ServiceName")
              .HasMaxLength(255);
            
            builder.ToTable("OrdersDetails");
        }
    }
}
