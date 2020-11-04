using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineComputerShop.Dal.Migrations
{
    public partial class Comment_DateTimeOfCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeOfCreation",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeOfCreation",
                table: "Comments");
        }
    }
}
