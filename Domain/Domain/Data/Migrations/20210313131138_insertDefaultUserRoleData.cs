using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Data.Migrations
{
    public partial class insertDefaultUserRoleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 13, 16, 11, 36, 925, DateTimeKind.Local).AddTicks(3679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 10, 9, 32, 30, 910, DateTimeKind.Local).AddTicks(3793));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 13, 16, 11, 36, 923, DateTimeKind.Local).AddTicks(7071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 10, 9, 32, 30, 908, DateTimeKind.Local).AddTicks(5410));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 10, 9, 32, 30, 910, DateTimeKind.Local).AddTicks(3793),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 13, 16, 11, 36, 925, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 10, 9, 32, 30, 908, DateTimeKind.Local).AddTicks(5410),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 13, 16, 11, 36, 923, DateTimeKind.Local).AddTicks(7071));
        }
    }
}
