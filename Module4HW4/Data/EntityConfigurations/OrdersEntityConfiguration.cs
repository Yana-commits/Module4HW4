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
    internal class OrdersEntityConfiguration : IEntityTypeConfiguration<OrdersEntity>
    {
        public void Configure(EntityTypeBuilder<OrdersEntity> builder)
        {
            builder.HasKey(h => h.OrderId);
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.OrderNumber).IsRequired();
            builder.Property(p => p.PaymentId).IsRequired();
            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.ShipDate).IsRequired();
            builder.Property(p => p.Deleted).IsRequired();
            builder.Property(p => p.PaymentDate).IsRequired();

            builder.HasOne(d => d.Customer).
                WithMany(p => p.Orders).
                HasForeignKey(d => d.CustomerId).
                OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Payment).
                WithOne(p => p.Order).
                HasForeignKey<PaymentEntity>(b => b.PaymentId).
                OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Shipper).
                WithMany(p => p.Orders).
                HasForeignKey(d => d.ShipperId).
                OnDelete(DeleteBehavior.Cascade);

        }
    }
}
