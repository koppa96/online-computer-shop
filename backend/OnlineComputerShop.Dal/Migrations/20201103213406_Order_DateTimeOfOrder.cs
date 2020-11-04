using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineComputerShop.Dal.Migrations
{
    public partial class Order_DateTimeOfOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeOfOrder",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeOfOrder",
                table: "Orders");
        }
    }
}
