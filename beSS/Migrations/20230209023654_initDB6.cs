using Microsoft.EntityFrameworkCore.Migrations;

namespace beSS.Migrations
{
    public partial class initDB6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Bill_BillID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Carts_CartID",
                table: "Bill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bill",
                table: "Bill");

            migrationBuilder.RenameTable(
                name: "Bill",
                newName: "Bills");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_CartID",
                table: "Bills",
                newName: "IX_Bills_CartID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bills",
                table: "Bills",
                column: "BillID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Bills_BillID",
                table: "AspNetUsers",
                column: "BillID",
                principalTable: "Bills",
                principalColumn: "BillID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Carts_CartID",
                table: "Bills",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Bills_BillID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Carts_CartID",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bills",
                table: "Bills");

            migrationBuilder.RenameTable(
                name: "Bills",
                newName: "Bill");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_CartID",
                table: "Bill",
                newName: "IX_Bill_CartID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bill",
                table: "Bill",
                column: "BillID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Bill_BillID",
                table: "AspNetUsers",
                column: "BillID",
                principalTable: "Bill",
                principalColumn: "BillID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Carts_CartID",
                table: "Bill",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
