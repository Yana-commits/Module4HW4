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
    internal class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(h => h.CategoryId);
            builder.Property(p => p.CategoryName).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Picture).IsRequired();
            builder.Property(p => p.Active).IsRequired();

            builder.HasMany(d => d.Products).
                WithOne(d => d.Category).
                HasForeignKey(p => p.CategoryId).
                OnDelete(DeleteBehavior.Cascade);
        }
    }
}
