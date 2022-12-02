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
    internal class CustomersEntityConfiguration : IEntityTypeConfiguration<CustomersEntity>
    {
        public void Configure(EntityTypeBuilder<CustomersEntity> builder)
        {
            builder.HasKey(h => h.CustomerId);
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.Class).IsRequired();
            builder.Property(p => p.Address).IsRequired();
        }
    }
}
