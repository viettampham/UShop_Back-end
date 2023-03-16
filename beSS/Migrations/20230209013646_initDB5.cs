using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace beSS.Migrations
{
    public partial class initDB5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductID",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductID",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityAvailable",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "Categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_OrderID",
                table: "Categories",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Orders_OrderID",
                table: "Categories",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Orders_OrderID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_OrderID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "QuantityAvailable",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Categories");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductID",
                table: "Orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductID",
                table: "Orders",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductID",
                table: "Orders",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
