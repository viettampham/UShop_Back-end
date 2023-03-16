using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace beSS.Migrations
{
    public partial class initDB7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Carts_CartID",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_CartID",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "Bills",
                newName: "Cartid");

            migrationBuilder.AddColumn<Guid>(
                name: "BillID",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Cartid",
                table: "Bills",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalMoneyCart",
                table: "Bills",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillID",
                table: "Orders",
                column: "BillID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Bills_BillID",
                table: "Orders",
                column: "BillID",
                principalTable: "Bills",
                principalColumn: "BillID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Bills_BillID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BillID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalMoneyCart",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "Cartid",
                table: "Bills",
                newName: "CartID");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartID",
                table: "Bills",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CartID",
                table: "Bills",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Carts_CartID",
                table: "Bills",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
