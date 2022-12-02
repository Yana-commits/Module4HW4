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
    internal class ProductsEntutyConfiguration : IEntityTypeConfiguration<ProductsEntity>
    {
        public void Configure(EntityTypeBuilder<ProductsEntity> builder)
        {
            builder.HasKey(h => h.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.ProductDescription).IsRequired();
            builder.Property(p => p.UnitPrice).IsRequired();
            builder.Property(p => p.SupplierId).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.CurrentOrder).IsRequired();


        }
    }
}
