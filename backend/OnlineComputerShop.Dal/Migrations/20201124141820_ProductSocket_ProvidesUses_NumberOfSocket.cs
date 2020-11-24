using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineComputerShop.Dal.Migrations
{
    public partial class ProductSocket_ProvidesUses_NumberOfSocket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfSocket",
                table: "ProductSockets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvidesUses",
                table: "ProductSockets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSocket",
                table: "ProductSockets");

            migrationBuilder.DropColumn(
                name: "ProvidesUses",
                table: "ProductSockets");
        }
    }
}
