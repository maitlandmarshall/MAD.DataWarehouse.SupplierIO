using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MAD.DataWarehouse.SupplierIO.Data
{
    public class SupplierIODbContext : DbContext
    {
        public SupplierIODbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Supplier>(cfg =>
            {
                cfg.HasKey(y => y.SupplierId);
                cfg.Property(y => y.SupplierId).HasMaxLength(200);
            });
        }
    }
}
