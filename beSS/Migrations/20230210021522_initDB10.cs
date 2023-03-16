using Microsoft.EntityFrameworkCore.Migrations;

namespace beSS.Migrations
{
    public partial class initDB10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Bills",
                newName: "IsPayed");

            migrationBuilder.AddColumn<bool>(
                name: "IsinCart",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuantityOrder",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsinBill",
                table: "Carts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsinCart",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "QuantityOrder",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsinBill",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "IsPayed",
                table: "Bills",
                newName: "Status");
        }
    }
}
