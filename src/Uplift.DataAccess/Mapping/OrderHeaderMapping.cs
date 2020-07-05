using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplift.Models;

namespace Uplift.DataAccess.Mapping
{
    public class OrderHeaderMapping : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(255);

            builder.Property(x => x.Phone)
                .HasMaxLength(20);

            builder.Property(x => x.Email)
                .HasMaxLength(100);

            builder.Property(x => x.Address)
                .HasMaxLength(255);

            builder.Property(x => x.City)
                .HasMaxLength(60);

            builder.Property(x => x.ZipCode)
                .HasMaxLength(16);

            builder.Property(x => x.Status)
                .HasMaxLength(20);

            builder.Property(x => x.Comments)
                .HasMaxLength(500);

            builder.ToTable("OrdersHeaders");
        }
    }
}
