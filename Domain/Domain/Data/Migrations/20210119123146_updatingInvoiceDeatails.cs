using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Data.Migrations
{
    public partial class updatingInvoiceDeatails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_SalesDetails_SalesDetailsId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Customers_CustomerId",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_CustomerId",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SalesDetailsId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "CustId",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "SalesDetailsId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "SalesDetails",
                newName: "ProductID");

            migrationBuilder.AddColumn<int>(
                name: "CustId",
                table: "SalesInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustId",
                table: "SalesInvoices");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "SalesDetails",
                newName: "ProductId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "SalesInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustId",
                table: "SalesDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesDetailsId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_CustomerId",
                table: "SalesInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SalesDetailsId",
                table: "Customers",
                column: "SalesDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_SalesDetails_SalesDetailsId",
                table: "Customers",
                column: "SalesDetailsId",
                principalTable: "SalesDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Customers_CustomerId",
                table: "SalesInvoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
