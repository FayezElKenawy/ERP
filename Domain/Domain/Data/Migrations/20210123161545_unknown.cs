using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Data.Migrations
{
    public partial class unknown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_SalesInvoices_SalesInvoiceId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SalesInvoiceId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustId",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomersId",
                table: "SalesInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_CustomersId",
                table: "SalesInvoices",
                column: "CustomersId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Customers_CustomersId",
                table: "SalesInvoices",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Customers_CustomersId",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_CustomersId",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "CustomersId",
                table: "SalesInvoices");

            migrationBuilder.AddColumn<int>(
                name: "CustId",
                table: "SalesInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesInvoiceId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SalesInvoiceId",
                table: "Customers",
                column: "SalesInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_SalesInvoices_SalesInvoiceId",
                table: "Customers",
                column: "SalesInvoiceId",
                principalTable: "SalesInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
