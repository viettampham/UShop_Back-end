using Microsoft.EntityFrameworkCore.Migrations;

namespace beSS.Migrations
{
    public partial class mainDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullNameUser",
                table: "Bills",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullNameUser",
                table: "Bills");
        }
    }
}
