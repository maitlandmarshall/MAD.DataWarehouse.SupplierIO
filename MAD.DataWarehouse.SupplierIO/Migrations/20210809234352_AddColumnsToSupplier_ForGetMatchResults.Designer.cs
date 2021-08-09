﻿// <auto-generated />
using System;
using MAD.DataWarehouse.SupplierIO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAD.DataWarehouse.SupplierIO.Migrations
{
    [DbContext(typeof(SupplierIODbContext))]
    [Migration("20210809234352_AddColumnsToSupplier_ForGetMatchResults")]
    partial class AddColumnsToSupplier_ForGetMatchResults
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MAD.DataWarehouse.SupplierIO.Data.CertificationDetail", b =>
                {
                    b.Property<string>("Agency")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Classification")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SupplierId")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Agency", "Classification", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("CertificationDetail");
                });

            modelBuilder.Entity("MAD.DataWarehouse.SupplierIO.Data.ContactDetail", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SupplierId")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ContactDetail");
                });

            modelBuilder.Entity("MAD.DataWarehouse.SupplierIO.Data.Supplier", b =>
                {
                    b.Property<string>("SupplierId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ActualEmployees")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActualRevenue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlternateSupplierNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Established")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ethnicity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAICS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAICSDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ownership")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Revenue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SIC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmallBusinessClassifications")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("MAD.DataWarehouse.SupplierIO.Data.CertificationDetail", b =>
                {
                    b.HasOne("MAD.DataWarehouse.SupplierIO.Data.Supplier", null)
                        .WithMany("CertificationDetail")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MAD.DataWarehouse.SupplierIO.Data.ContactDetail", b =>
                {
                    b.HasOne("MAD.DataWarehouse.SupplierIO.Data.Supplier", null)
                        .WithMany("ContactDetail")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MAD.DataWarehouse.SupplierIO.Data.Supplier", b =>
                {
                    b.Navigation("CertificationDetail");

                    b.Navigation("ContactDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
