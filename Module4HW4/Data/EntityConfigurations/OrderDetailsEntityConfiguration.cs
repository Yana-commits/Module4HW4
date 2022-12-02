using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Data.EntityConfigurations
{
    internal class OrderDetailsEntityConfiguration : IEntityTypeConfiguration<OrderDetailsEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailsEntity> builder)
        {
            builder.HasKey(h => h.OrderId);
            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.OrderNumber).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.ShipDate).IsRequired();

            builder.HasOne(d => d.Order).
               WithOne(p => p.OrderDetails).
               HasForeignKey<OrderDetailsEntity>(b => b.OrderNumber).
               OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Product).
                WithMany(p => p.OrderDetails).
                HasForeignKey(d => d.ProductId).
                OnDelete(DeleteBehavior.Cascade);
        }
    }
}
