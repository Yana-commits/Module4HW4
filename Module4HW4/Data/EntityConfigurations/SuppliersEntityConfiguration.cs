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
    internal class SuppliersEntityConfiguration : IEntityTypeConfiguration<SuppliersEntity>
    {
        public void Configure(EntityTypeBuilder<SuppliersEntity> builder)
        {
            builder.HasKey(h => h.SupplierId);
            builder.Property(p => p.CompanyName).IsRequired();
            builder.Property(p => p.ContractName).IsRequired();
            builder.Property(p => p.ContractTitle).IsRequired();
            builder.Property(p => p.Address).IsRequired();

            builder.HasMany(d => d.Products).
                WithOne(p => p.Supplier).
                HasForeignKey(p => p.SupplierId).
                OnDelete(DeleteBehavior.Cascade);
        }
    }
}
