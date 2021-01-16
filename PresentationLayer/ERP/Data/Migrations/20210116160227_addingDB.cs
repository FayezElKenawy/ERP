using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Data.Migrations
{
    public partial class addingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustArName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustEnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustBalance = table.Column<double>(type: "float", nullable: false),
                    CustOpenBalance = table.Column<double>(type: "float", nullable: false),
                    AccountNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoices",
                columns: table => new
                {
                    InvoiceNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceTotal = table.Column<double>(type: "float", nullable: false),
                    InvoiceDiscount = table.Column<double>(type: "float", nullable: false),
                    InvoiceNetTotal = table.Column<double>(type: "float", nullable: false),
                    InvoiceType = table.Column<int>(type: "int", nullable: false),
                    InvoicePaid = table.Column<double>(type: "float", nullable: false),
                    InvoiceChange = table.Column<double>(type: "float", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: true),
                    CustomerCustId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoices", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_Customers_CustomerCustId",
                        column: x => x.CustomerCustId,
                        principalTable: "Customers",
                        principalColumn: "CustId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_CustomerCustId",
                table: "SalesInvoices",
                column: "CustomerCustId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_ProductsId",
                table: "SalesInvoices",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
