using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineComputerShop.Dal.Migrations
{
    public partial class ConfiguratorOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfiguratorOrder",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfiguratorOrder",
                table: "Categories");
        }
    }
}
