using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace beSS.Migrations
{
    public partial class initDBO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<Guid>>(
                name: "CategoryIDs",
                table: "Products",
                type: "uuid[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryIDs",
                table: "Products");
        }
    }
}
