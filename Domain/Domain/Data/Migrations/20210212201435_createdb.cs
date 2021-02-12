using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Data.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustArName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustEnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustBalance = table.Column<double>(type: "float", nullable: false),
                    CustOpenBalance = table.Column<double>(type: "float", nullable: false),
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    SalePrice = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Balance = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    OpenBalance = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    LastBalance = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    LastCost = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    OpenCost = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ForignCost = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 2, 12, 23, 14, 34, 411, DateTimeKind.Local).AddTicks(767)),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 2, 12, 23, 14, 34, 413, DateTimeKind.Local).AddTicks(684)),
                    CreatedById = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoices",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InvoiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceTotal = table.Column<double>(type: "float", nullable: false),
                    InvoiceDiscount = table.Column<double>(type: "float", nullable: false),
                    InvoiceNetTotal = table.Column<double>(type: "float", nullable: false),
                    InvoiceType = table.Column<int>(type: "int", nullable: false),
                    InvoicePaid = table.Column<double>(type: "float", nullable: false),
                    InvoiceChange = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoices", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_Customers_CustID",
                        column: x => x.CustID,
                        principalTable: "Customers",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    SalesPrice = table.Column<double>(type: "float", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: true),
                    discount = table.Column<double>(type: "float", nullable: true),
                    VatAmount = table.Column<double>(type: "float", nullable: true),
                    TotalWithVat = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => new { x.ProductID, x.InvoiceId });
                    table.ForeignKey(
                        name: "FK_SalesDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesDetails_SalesInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "SalesInvoices",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_InvoiceId",
                table: "SalesDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_CustID",
                table: "SalesInvoices",
                column: "CustID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
