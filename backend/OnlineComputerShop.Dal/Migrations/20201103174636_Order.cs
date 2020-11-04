using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineComputerShop.Dal.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Orders");
        }
    }
}
