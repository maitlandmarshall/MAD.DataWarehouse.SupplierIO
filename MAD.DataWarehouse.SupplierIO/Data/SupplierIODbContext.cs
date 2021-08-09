using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

                var enumOfStringToStringConverter = new ValueConverter<IEnumerable<string>, string>(
                    v => string.Join(",", v),
                    v => v.Split(new[] { ',' }).AsEnumerable());

                cfg.Property(y => y.AlternateSupplierNames).HasConversion(enumOfStringToStringConverter);
                cfg.Property(y => y.NAICS).HasConversion(enumOfStringToStringConverter);
                cfg.Property(y => y.NAICSDescription).HasConversion(enumOfStringToStringConverter);
                cfg.Property(y => y.Ownership).HasConversion(enumOfStringToStringConverter);
                cfg.Property(y => y.SIC).HasConversion(enumOfStringToStringConverter);
                cfg.Property(y => y.SmallBusinessClassifications).HasConversion(enumOfStringToStringConverter);

                cfg.HasMany(y => y.CertificationDetail).WithOne().HasForeignKey("SupplierId");
                cfg.HasMany(y => y.ContactDetail).WithOne().HasForeignKey("SupplierId");
            });

            modelBuilder.Entity<CertificationDetail>(cfg =>
            {
                cfg.HasKey(nameof(CertificationDetail.Agency), nameof(CertificationDetail.Classification), "SupplierId");
            });

            modelBuilder.Entity<ContactDetail>(cfg =>
            {
                cfg.HasKey(nameof(ContactDetail.Email), "SupplierId");
            });
        }
    }
}
