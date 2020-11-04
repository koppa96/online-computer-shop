using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineComputerShop.Dal.Migrations
{
    public partial class BasketItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategorySocket_Category_CategoryId",
                table: "CategorySocket");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorySocket_Socket_SocketId",
                table: "CategorySocket");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product_ProductId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Product_ProductId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_AspNetUsers_UserId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSocket_Product_ProductId",
                table: "ProductSocket");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSocket_Socket_SocketId",
                table: "ProductSocket");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyType_Category_CategoryId",
                table: "PropertyType");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyValue_Product_ProductId",
                table: "PropertyValue");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyValue_PropertyType_PropertyTypeId",
                table: "PropertyValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Socket",
                table: "Socket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyValue",
                table: "PropertyValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyType",
                table: "PropertyType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSocket",
                table: "ProductSocket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_UserId",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategorySocket",
                table: "CategorySocket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "Socket",
                newName: "Sockets");

            migrationBuilder.RenameTable(
                name: "PropertyValue",
                newName: "PropertyValues");

            migrationBuilder.RenameTable(
                name: "PropertyType",
                newName: "PropertyTypes");

            migrationBuilder.RenameTable(
                name: "ProductSocket",
                newName: "ProductSockets");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "CategorySocket",
                newName: "CategorySockets");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyValue_PropertyTypeId",
                table: "PropertyValues",
                newName: "IX_PropertyValues_PropertyTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyValue_ProductId",
                table: "PropertyValues",
                newName: "IX_PropertyValues_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyType_CategoryId",
                table: "PropertyTypes",
                newName: "IX_PropertyTypes_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSocket_SocketId",
                table: "ProductSockets",
                newName: "IX_ProductSockets_SocketId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSocket_ProductId",
                table: "ProductSockets",
                newName: "IX_ProductSockets_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ProductId",
                table: "Comments",
                newName: "IX_Comments_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CategorySocket_SocketId",
                table: "CategorySockets",
                newName: "IX_CategorySockets_SocketId");

            migrationBuilder.RenameIndex(
                name: "IX_CategorySocket_CategoryId",
                table: "CategorySockets",
                newName: "IX_CategorySockets_CategoryId");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PricePerPiece",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sockets",
                table: "Sockets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyValues",
                table: "PropertyValues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyTypes",
                table: "PropertyTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSockets",
                table: "ProductSockets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategorySockets",
                table: "CategorySockets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_UserId",
                table: "BasketItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySockets_Categories_CategoryId",
                table: "CategorySockets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySockets_Sockets_SocketId",
                table: "CategorySockets",
                column: "SocketId",
                principalTable: "Sockets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSockets_Products_ProductId",
                table: "ProductSockets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSockets_Sockets_SocketId",
                table: "ProductSockets",
                column: "SocketId",
                principalTable: "Sockets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTypes_Categories_CategoryId",
                table: "PropertyTypes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyValues_Products_ProductId",
                table: "PropertyValues",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyValues_PropertyTypes_PropertyTypeId",
                table: "PropertyValues",
                column: "PropertyTypeId",
                principalTable: "PropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategorySockets_Categories_CategoryId",
                table: "CategorySockets");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorySockets_Sockets_SocketId",
                table: "CategorySockets");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSockets_Products_ProductId",
                table: "ProductSockets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSockets_Sockets_SocketId",
                table: "ProductSockets");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTypes_Categories_CategoryId",
                table: "PropertyTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyValues_Products_ProductId",
                table: "PropertyValues");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyValues_PropertyTypes_PropertyTypeId",
                table: "PropertyValues");

            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sockets",
                table: "Sockets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyValues",
                table: "PropertyValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyTypes",
                table: "PropertyTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSockets",
                table: "ProductSockets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategorySockets",
                table: "CategorySockets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PricePerPiece",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Sockets",
                newName: "Socket");

            migrationBuilder.RenameTable(
                name: "PropertyValues",
                newName: "PropertyValue");

            migrationBuilder.RenameTable(
                name: "PropertyTypes",
                newName: "PropertyType");

            migrationBuilder.RenameTable(
                name: "ProductSockets",
                newName: "ProductSocket");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "CategorySockets",
                newName: "CategorySocket");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyValues_PropertyTypeId",
                table: "PropertyValue",
                newName: "IX_PropertyValue_PropertyTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyValues_ProductId",
                table: "PropertyValue",
                newName: "IX_PropertyValue_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyTypes_CategoryId",
                table: "PropertyType",
                newName: "IX_PropertyType_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSockets_SocketId",
                table: "ProductSocket",
                newName: "IX_ProductSocket_SocketId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSockets_ProductId",
                table: "ProductSocket",
                newName: "IX_ProductSocket_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItem",
                newName: "IX_OrderItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ProductId",
                table: "Comment",
                newName: "IX_Comment_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CategorySockets_SocketId",
                table: "CategorySocket",
                newName: "IX_CategorySocket_SocketId");

            migrationBuilder.RenameIndex(
                name: "IX_CategorySockets_CategoryId",
                table: "CategorySocket",
                newName: "IX_CategorySocket_CategoryId");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "OrderItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Socket",
                table: "Socket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyValue",
                table: "PropertyValue",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyType",
                table: "PropertyType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSocket",
                table: "ProductSocket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategorySocket",
                table: "CategorySocket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_UserId",
                table: "OrderItem",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySocket_Category_CategoryId",
                table: "CategorySocket",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySocket_Socket_SocketId",
                table: "CategorySocket",
                column: "SocketId",
                principalTable: "Socket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Product_ProductId",
                table: "Comment",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Product_ProductId",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_AspNetUsers_UserId",
                table: "OrderItem",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSocket_Product_ProductId",
                table: "ProductSocket",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSocket_Socket_SocketId",
                table: "ProductSocket",
                column: "SocketId",
                principalTable: "Socket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyType_Category_CategoryId",
                table: "PropertyType",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyValue_Product_ProductId",
                table: "PropertyValue",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyValue_PropertyType_PropertyTypeId",
                table: "PropertyValue",
                column: "PropertyTypeId",
                principalTable: "PropertyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
