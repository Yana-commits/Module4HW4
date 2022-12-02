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
    internal class ShippersEntityConfiguration : IEntityTypeConfiguration<ShippersEntity>
    {
        public void Configure(EntityTypeBuilder<ShippersEntity> builder)
        {
            builder.HasKey(h => h.ShipperId);
            builder.Property(p => p.CompanyName).IsRequired();
            builder.Property(p => p.Phone).IsRequired();
        }
    }
}
