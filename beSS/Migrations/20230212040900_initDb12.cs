using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace beSS.Migrations
{
    public partial class initDb12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Bills_BillID",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "BillID",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Bills_BillID",
                table: "Orders",
                column: "BillID",
                principalTable: "Bills",
                principalColumn: "BillID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Bills_BillID",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "BillID",
                table: "Orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Bills_BillID",
                table: "Orders",
                column: "BillID",
                principalTable: "Bills",
                principalColumn: "BillID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
