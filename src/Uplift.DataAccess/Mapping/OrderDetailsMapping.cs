using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;

namespace Uplift.DataAccess.Mapping
{
    public class OrderDetailsMapping : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ServiceName)
                .HasMaxLength(255);

            builder.ToTable("OrdersDetails");
        }
    }
}
