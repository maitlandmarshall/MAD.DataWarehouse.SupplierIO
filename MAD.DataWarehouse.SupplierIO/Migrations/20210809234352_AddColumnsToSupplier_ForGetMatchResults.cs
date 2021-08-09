using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAD.DataWarehouse.SupplierIO.Migrations
{
    public partial class AddColumnsToSupplier_ForGetMatchResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActualEmployees",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActualRevenue",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlternateSupplierNames",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Established",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ethnicity",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NAICS",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NAICSDescription",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ownership",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Revenue",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIC",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallBusinessClassifications",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CertificationDetail",
                columns: table => new
                {
                    Agency = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationDetail", x => new { x.Agency, x.Classification, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_CertificationDetail_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetail",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetail", x => new { x.Email, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_ContactDetail_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificationDetail_SupplierId",
                table: "CertificationDetail",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetail_SupplierId",
                table: "ContactDetail",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificationDetail");

            migrationBuilder.DropTable(
                name: "ContactDetail");

            migrationBuilder.DropColumn(
                name: "ActualEmployees",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ActualRevenue",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "AlternateSupplierNames",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Established",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Ethnicity",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "NAICS",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "NAICSDescription",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Ownership",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Revenue",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SIC",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SmallBusinessClassifications",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Supplier");
        }
    }
}
