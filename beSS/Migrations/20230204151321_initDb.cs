using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace beSS.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryIDs",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductIDs",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "OrderIDs",
                table: "Carts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductID",
                table: "Orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartID",
                table: "Orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<int>(
                name: "TotalMoneyCart",
                table: "Carts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "CartID",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesCategoryID = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsProductID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesCategoryID, x.ProductsProductID });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesCategoryID",
                        column: x => x.CategoriesCategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsProductID",
                        column: x => x.ProductsProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartID",
                table: "Orders",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductID",
                table: "Orders",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartID",
                table: "AspNetUsers",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsProductID",
                table: "CategoryProduct",
                column: "ProductsProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carts_CartID",
                table: "AspNetUsers",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductID",
                table: "Orders",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_CartID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carts_CartID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CartID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TotalMoneyCart",
                table: "Carts");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "CategoryIDs",
                table: "Products",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductID",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CartID",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "ProductIDs",
                table: "Categories",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "OrderIDs",
                table: "Carts",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CartID",
                table: "AspNetUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
