using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Data.Migrations
{
    public partial class modifayTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "SalesDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesInvoiceId",
                table: "SalesDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesInvoiceId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SalesInvoiceId",
                table: "SalesDetails",
                column: "SalesInvoiceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_SalesInvoices_SalesInvoiceId",
                table: "SalesDetails",
                column: "SalesInvoiceId",
                principalTable: "SalesInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_SalesInvoices_SalesInvoiceId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_SalesInvoices_SalesInvoiceId",
                table: "SalesDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetails_SalesInvoiceId",
                table: "SalesDetails");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SalesInvoiceId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceId",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceId",
                table: "Customers");
        }
    }
}
