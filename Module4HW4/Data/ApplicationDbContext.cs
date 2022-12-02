using Microsoft.EntityFrameworkCore;
using Module4HW4.Data.Entities;
using Module4HW4.Data.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryEntity> Categories { get; set; } = null!;
        public DbSet<CustomersEntity> Customers { get; set; } = null!;
        public DbSet<OrderDetailsEntity> OrderDetails { get; set; } = null!;
        public DbSet<OrdersEntity> Orders { get; set; } = null!;
        public DbSet<PaymentEntity> Payments { get; set; } = null!;
        public DbSet<ProductsEntity> Products { get; set; } = null!;
        public DbSet<ShippersEntity> Shippers { get; set; } = null!;
        public DbSet<SuppliersEntity> Suppliers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomersEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsEntutyConfiguration());
            modelBuilder.ApplyConfiguration(new ShippersEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SuppliersEntityConfiguration());
            modelBuilder.UseHiLo();
        }
    }
}
