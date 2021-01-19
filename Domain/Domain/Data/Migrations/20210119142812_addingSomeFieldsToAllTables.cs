using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Data.Migrations
{
    public partial class addingSomeFieldsToAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceType",
                table: "SalesDetails");

            migrationBuilder.RenameColumn(
                name: "InvoiceTotal",
                table: "SalesDetails",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "InvoicePaid",
                table: "SalesDetails",
                newName: "VatAmount");

            migrationBuilder.RenameColumn(
                name: "InvoiceNetTotal",
                table: "SalesDetails",
                newName: "TotalWithVat");

            migrationBuilder.RenameColumn(
                name: "InvoiceDiscount",
                table: "SalesDetails",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "InvoiceChange",
                table: "SalesDetails",
                newName: "SalesPrice");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "SalesDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "SalesDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ForignCost",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LastBalance",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LastCost",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OpenBalance",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OpenCost",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ForignCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastBalance",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OpenBalance",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OpenCost",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "discount",
                table: "SalesDetails",
                newName: "InvoiceTotal");

            migrationBuilder.RenameColumn(
                name: "VatAmount",
                table: "SalesDetails",
                newName: "InvoicePaid");

            migrationBuilder.RenameColumn(
                name: "TotalWithVat",
                table: "SalesDetails",
                newName: "InvoiceNetTotal");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "SalesDetails",
                newName: "InvoiceDiscount");

            migrationBuilder.RenameColumn(
                name: "SalesPrice",
                table: "SalesDetails",
                newName: "InvoiceChange");

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                table: "SalesDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InvoiceType",
                table: "SalesDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
