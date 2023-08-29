using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bangazon.Migrations
{
    public partial class seedOrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatuses_Orders_OrderId",
                table: "OrderStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTypes_Orders_OrderId",
                table: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTypes_OrderId",
                table: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_OrderStatuses_OrderId",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderStatuses");

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrdersId", "ProductsId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 4 }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "PaymentTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderStatuses",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 8, 23, 15, 15, 26, 215, DateTimeKind.Local).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 8, 23, 15, 15, 26, 215, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_OrderId",
                table: "PaymentTypes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatuses_OrderId",
                table: "OrderStatuses",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatuses_Orders_OrderId",
                table: "OrderStatuses",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTypes_Orders_OrderId",
                table: "PaymentTypes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
