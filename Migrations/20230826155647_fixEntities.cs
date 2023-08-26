using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bangazon.Migrations
{
    public partial class fixEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 8, 26, 10, 56, 47, 121, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 8, 26, 10, 56, 47, 121, DateTimeKind.Local).AddTicks(3044));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 8, 26, 10, 33, 53, 99, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 8, 26, 10, 33, 53, 99, DateTimeKind.Local).AddTicks(5554));
        }
    }
}
