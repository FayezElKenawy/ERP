using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Data.Migrations
{
    public partial class modifyDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_Products_ProductID",
                table: "SalesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_SalesInvoices_SalesInvoicesId",
                table: "SalesDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetails_SalesInvoicesId",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "SalesInvoicesId",
                table: "SalesDetails");

            migrationBuilder.AddColumn<int>(
                name: "SalesDetailsInvoiceId",
                table: "SalesInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesDetailsProductID",
                table: "SalesInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesDetailsInvoiceId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesDetailsProductID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_SalesDetailsProductID_SalesDetailsInvoiceId",
                table: "SalesInvoices",
                columns: new[] { "SalesDetailsProductID", "SalesDetailsInvoiceId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SalesDetailsProductID_SalesDetailsInvoiceId",
                table: "Products",
                columns: new[] { "SalesDetailsProductID", "SalesDetailsInvoiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SalesDetails_SalesDetailsProductID_SalesDetailsInvoiceId",
                table: "Products",
                columns: new[] { "SalesDetailsProductID", "SalesDetailsInvoiceId" },
                principalTable: "SalesDetails",
                principalColumns: new[] { "ProductID", "InvoiceId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_SalesDetails_SalesDetailsProductID_SalesDetailsInvoiceId",
                table: "SalesInvoices",
                columns: new[] { "SalesDetailsProductID", "SalesDetailsInvoiceId" },
                principalTable: "SalesDetails",
                principalColumns: new[] { "ProductID", "InvoiceId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SalesDetails_SalesDetailsProductID_SalesDetailsInvoiceId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_SalesDetails_SalesDetailsProductID_SalesDetailsInvoiceId",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_SalesDetailsProductID_SalesDetailsInvoiceId",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Products_SalesDetailsProductID_SalesDetailsInvoiceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalesDetailsInvoiceId",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "SalesDetailsProductID",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "SalesDetailsInvoiceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalesDetailsProductID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "SalesInvoicesId",
                table: "SalesDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SalesInvoicesId",
                table: "SalesDetails",
                column: "SalesInvoicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_Products_ProductID",
                table: "SalesDetails",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_SalesInvoices_SalesInvoicesId",
                table: "SalesDetails",
                column: "SalesInvoicesId",
                principalTable: "SalesInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
