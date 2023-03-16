using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace beSS.Migrations
{
    public partial class initDBX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<Guid>>(
                name: "ProductIDs",
                table: "Bills",
                type: "uuid[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductIDs",
                table: "Bills");
        }
    }
}
