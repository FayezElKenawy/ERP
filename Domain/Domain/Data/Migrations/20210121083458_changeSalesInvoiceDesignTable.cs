using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Data.Migrations
{
    public partial class changeSalesInvoiceDesignTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Products_ProductsId",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_ProductsId",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "SalesInvoices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "SalesInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_ProductsId",
                table: "SalesInvoices",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Products_ProductsId",
                table: "SalesInvoices",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
