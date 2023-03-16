using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace beSS.Migrations
{
    public partial class initDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_CartID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "AspNetUsers",
                newName: "BillID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CartID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_BillID");

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    CartID = table.Column<Guid>(type: "uuid", nullable: true),
                    AddressTranfer = table.Column<string>(type: "text", nullable: true),
                    NameCustomer = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillID);
                    table.ForeignKey(
                        name: "FK_Bill_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_CartID",
                table: "Bill",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Bill_BillID",
                table: "AspNetUsers",
                column: "BillID",
                principalTable: "Bill",
                principalColumn: "BillID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Bill_BillID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.RenameColumn(
                name: "BillID",
                table: "AspNetUsers",
                newName: "CartID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_BillID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carts_CartID",
                table: "AspNetUsers",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
