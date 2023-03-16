using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace beSS.Migrations
{
    public partial class initDb11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Carts_CartID",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carts_CartID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Bills_CartID",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "IsinCart",
                table: "Orders",
                newName: "IsinBill");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "Orders",
                newName: "BillID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CartID",
                table: "Orders",
                newName: "IX_Orders_BillID");

            migrationBuilder.AddColumn<int>(
                name: "TotalBill",
                table: "Bills",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropColumn(
                name: "TotalBill",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "IsinBill",
                table: "Orders",
                newName: "IsinCart");

            migrationBuilder.RenameColumn(
                name: "BillID",
                table: "Orders",
                newName: "CartID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BillID",
                table: "Orders",
                newName: "IX_Orders_CartID");

            migrationBuilder.AddColumn<Guid>(
                name: "CartID",
                table: "Bills",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartID = table.Column<Guid>(type: "uuid", nullable: false),
                    IsinBill = table.Column<bool>(type: "boolean", nullable: false),
                    TotalMoneyCart = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartID);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carts_CartID",
                table: "Orders",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
