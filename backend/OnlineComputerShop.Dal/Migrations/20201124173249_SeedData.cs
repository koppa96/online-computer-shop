using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineComputerShop.Dal.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"), "Alaplapok" },
                    { new Guid("61f9f877-85b8-42b1-a5a0-ffeba89b596b"), "Processzorok" },
                    { new Guid("50382070-40b1-42e9-a22d-0c79af948cfd"), "Memóriák" }
                });

            migrationBuilder.InsertData(
                table: "Sockets",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e48a3661-51c1-4638-87da-7d7bdf6b459f"), "LGA-1150" },
                    { new Guid("7190a380-dc61-44db-b4e1-1111c9c11d57"), "LGA-775" },
                    { new Guid("9ebfab45-564a-45cd-b787-289fe75cf433"), "DDR4" },
                    { new Guid("c41c004d-0b61-4576-a732-27c1ae5b3785"), "DDR3" }
                });

            migrationBuilder.InsertData(
                table: "CategorySockets",
                columns: new[] { "Id", "CategoryId", "SocketId" },
                values: new object[,]
                {
                    { new Guid("724e0f4b-7097-4c1d-adce-add2da917608"), new Guid("50382070-40b1-42e9-a22d-0c79af948cfd"), new Guid("c41c004d-0b61-4576-a732-27c1ae5b3785") },
                    { new Guid("91f6300a-53fa-4f48-8f94-8f4c2b253e54"), new Guid("50382070-40b1-42e9-a22d-0c79af948cfd"), new Guid("9ebfab45-564a-45cd-b787-289fe75cf433") },
                    { new Guid("5a2ed25d-8d27-4b2f-946d-80b81102f10a"), new Guid("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"), new Guid("9ebfab45-564a-45cd-b787-289fe75cf433") },
                    { new Guid("bcb1475d-34f3-4c15-a418-a57c19913bcf"), new Guid("61f9f877-85b8-42b1-a5a0-ffeba89b596b"), new Guid("7190a380-dc61-44db-b4e1-1111c9c11d57") },
                    { new Guid("b1893112-fea5-46fb-9d08-3bfdc5ac4284"), new Guid("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"), new Guid("7190a380-dc61-44db-b4e1-1111c9c11d57") },
                    { new Guid("dbaa3025-fbee-4bed-83d1-daaf7bb5b1ce"), new Guid("61f9f877-85b8-42b1-a5a0-ffeba89b596b"), new Guid("e48a3661-51c1-4638-87da-7d7bdf6b459f") },
                    { new Guid("bcd10130-ba36-4f5e-b93a-cd5b557adae8"), new Guid("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"), new Guid("e48a3661-51c1-4638-87da-7d7bdf6b459f") },
                    { new Guid("136a1f85-f331-46f0-85f8-53a578edbc6c"), new Guid("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"), new Guid("c41c004d-0b61-4576-a732-27c1ae5b3785") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("7a97b0b5-49b3-4edc-bb95-128252180473"), new Guid("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis.", "Gigabyte Z97P-D3", 32000 },
                    { new Guid("90a79691-4f7d-43b2-875c-fe44d3fcfdde"), new Guid("50382070-40b1-42e9-a22d-0c79af948cfd"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis.", "Kingston 8G198984135HUAA", 20000 },
                    { new Guid("b782f182-3802-4ef8-8e49-f8a48f1fd8a3"), new Guid("61f9f877-85b8-42b1-a5a0-ffeba89b596b"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis.", "Intel Core i3-4300", 27000 },
                    { new Guid("6aee5bea-5dd9-4e03-97e2-a59ea2e6cbc2"), new Guid("61f9f877-85b8-42b1-a5a0-ffeba89b596b"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis.", "Intel Core i5-8500", 61000 },
                    { new Guid("b30a9a31-0990-46d2-b7df-10010854e382"), new Guid("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis.", "Gigabyte H631-X2", 21000 },
                    { new Guid("6381e5b5-8d60-4109-9fe8-6fcfb73e20ea"), new Guid("50382070-40b1-42e9-a22d-0c79af948cfd"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis.", "Kinston 4G988498412333EE", 15000 }
                });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("ee2a6963-5ccd-4ef9-ab46-78b25f3e011e"), new Guid("50382070-40b1-42e9-a22d-0c79af948cfd"), "Frekvencia" },
                    { new Guid("32dfbae1-68df-416e-be73-0b959868b14d"), new Guid("61f9f877-85b8-42b1-a5a0-ffeba89b596b"), "Szálak száma" },
                    { new Guid("469c5262-c495-4327-b39a-129fd6a6bbd2"), new Guid("61f9f877-85b8-42b1-a5a0-ffeba89b596b"), "Magok száma" },
                    { new Guid("d9a63b4a-d2d0-4963-b9fb-24da15622686"), new Guid("61f9f877-85b8-42b1-a5a0-ffeba89b596b"), "Órajel" },
                    { new Guid("0402abd1-9d91-44e3-8207-525add7fb3b2"), new Guid("50382070-40b1-42e9-a22d-0c79af948cfd"), "Méret" }
                });

            migrationBuilder.InsertData(
                table: "ProductSockets",
                columns: new[] { "Id", "NumberOfSocket", "ProductId", "ProvidesUses", "SocketId" },
                values: new object[,]
                {
                    { new Guid("d6103102-7067-4f9a-80b7-f696b0f4988a"), 1, new Guid("7a97b0b5-49b3-4edc-bb95-128252180473"), 0, new Guid("e48a3661-51c1-4638-87da-7d7bdf6b459f") },
                    { new Guid("9889871d-abd8-4e50-93e6-1294df5dd751"), 1, new Guid("7a97b0b5-49b3-4edc-bb95-128252180473"), 0, new Guid("9ebfab45-564a-45cd-b787-289fe75cf433") },
                    { new Guid("3b367888-5194-4d44-8ac9-499f381a3980"), 1, new Guid("b30a9a31-0990-46d2-b7df-10010854e382"), 0, new Guid("7190a380-dc61-44db-b4e1-1111c9c11d57") },
                    { new Guid("ee3ff4e6-56ae-4f00-ad5a-3bf135bb8802"), 1, new Guid("b30a9a31-0990-46d2-b7df-10010854e382"), 0, new Guid("c41c004d-0b61-4576-a732-27c1ae5b3785") },
                    { new Guid("2ea916a6-30fd-40b1-87e1-10f9c047e49f"), 1, new Guid("6aee5bea-5dd9-4e03-97e2-a59ea2e6cbc2"), 1, new Guid("e48a3661-51c1-4638-87da-7d7bdf6b459f") },
                    { new Guid("7e231b63-30b5-4f9d-946e-cd23781c0beb"), 1, new Guid("b782f182-3802-4ef8-8e49-f8a48f1fd8a3"), 1, new Guid("7190a380-dc61-44db-b4e1-1111c9c11d57") },
                    { new Guid("d09b294f-ea4b-4478-a818-2aa3f85792f0"), 1, new Guid("6381e5b5-8d60-4109-9fe8-6fcfb73e20ea"), 1, new Guid("c41c004d-0b61-4576-a732-27c1ae5b3785") },
                    { new Guid("1f3f2462-8dc1-4763-a8de-f342289e64c6"), 1, new Guid("90a79691-4f7d-43b2-875c-fe44d3fcfdde"), 1, new Guid("9ebfab45-564a-45cd-b787-289fe75cf433") }
                });

            migrationBuilder.InsertData(
                table: "PropertyValues",
                columns: new[] { "Id", "ProductId", "PropertyTypeId", "Value" },
                values: new object[,]
                {
                    { new Guid("164d49bf-17ea-4953-b1f1-48185ada8691"), new Guid("6381e5b5-8d60-4109-9fe8-6fcfb73e20ea"), new Guid("0402abd1-9d91-44e3-8207-525add7fb3b2"), "4GB" },
                    { new Guid("e6792b58-98e5-4a6c-b90f-7446df11df05"), new Guid("90a79691-4f7d-43b2-875c-fe44d3fcfdde"), new Guid("0402abd1-9d91-44e3-8207-525add7fb3b2"), "8GB" },
                    { new Guid("9992633b-d22b-4c2c-9593-822cc789e157"), new Guid("b782f182-3802-4ef8-8e49-f8a48f1fd8a3"), new Guid("32dfbae1-68df-416e-be73-0b959868b14d"), "4" },
                    { new Guid("8ee761ec-cbbb-4465-913c-e92ed1187fec"), new Guid("7a97b0b5-49b3-4edc-bb95-128252180473"), new Guid("469c5262-c495-4327-b39a-129fd6a6bbd2"), "4" },
                    { new Guid("25a4799a-437c-46be-baae-1547f66ce9c2"), new Guid("b782f182-3802-4ef8-8e49-f8a48f1fd8a3"), new Guid("469c5262-c495-4327-b39a-129fd6a6bbd2"), "4" },
                    { new Guid("409b594f-a85c-4415-90a0-800232387c27"), new Guid("90a79691-4f7d-43b2-875c-fe44d3fcfdde"), new Guid("ee2a6963-5ccd-4ef9-ab46-78b25f3e011e"), "3200Mhz" },
                    { new Guid("5b0218c3-eade-4828-8b8d-e0a29132f634"), new Guid("b782f182-3802-4ef8-8e49-f8a48f1fd8a3"), new Guid("d9a63b4a-d2d0-4963-b9fb-24da15622686"), "3.40Ghz" },
                    { new Guid("0ec36c53-c2d3-4694-83ca-7480cb84495e"), new Guid("7a97b0b5-49b3-4edc-bb95-128252180473"), new Guid("d9a63b4a-d2d0-4963-b9fb-24da15622686"), "3.80Ghz" },
                    { new Guid("6015bcba-bebc-4353-8810-8a6d14ab8ade"), new Guid("7a97b0b5-49b3-4edc-bb95-128252180473"), new Guid("32dfbae1-68df-416e-be73-0b959868b14d"), "8" },
                    { new Guid("c625d924-5b0a-4c35-a825-ada3db63a206"), new Guid("6381e5b5-8d60-4109-9fe8-6fcfb73e20ea"), new Guid("ee2a6963-5ccd-4ef9-ab46-78b25f3e011e"), "1600Mhz" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategorySockets",
                keyColumn: "Id",
                keyValue: new Guid("136a1f85-f331-46f0-85f8-53a578edbc6c"));

            migrationBuilder.DeleteData(
                table: "CategorySockets",
                keyColumn: "Id",
                keyValue: new Guid("5a2ed25d-8d27-4b2f-946d-80b81102f10a"));

            migrationBuilder.DeleteData(
                table: "CategorySockets",
                keyColumn: "Id",
                keyValue: new Guid("724e0f4b-7097-4c1d-adce-add2da917608"));

            migrationBuilder.DeleteData(
                table: "CategorySockets",
                keyColumn: "Id",
                keyValue: new Guid("91f6300a-53fa-4f48-8f94-8f4c2b253e54"));

            migrationBuilder.DeleteData(
                table: "CategorySockets",
                keyColumn: "Id",
                keyValue: new Guid("b1893112-fea5-46fb-9d08-3bfdc5ac4284"));

            migrationBuilder.DeleteData(
                table: "CategorySockets",
                keyColumn: "Id",
                keyValue: new Guid("bcb1475d-34f3-4c15-a418-a57c19913bcf"));

            migrationBuilder.DeleteData(
                table: "CategorySockets",
                keyColumn: "Id",
                keyValue: new Guid("bcd10130-ba36-4f5e-b93a-cd5b557adae8"));

            migrationBuilder.DeleteData(
                table: "CategorySockets",
                keyColumn: "Id",
                keyValue: new Guid("dbaa3025-fbee-4bed-83d1-daaf7bb5b1ce"));

            migrationBuilder.DeleteData(
                table: "ProductSockets",
                keyColumn: "Id",
                keyValue: new Guid("1f3f2462-8dc1-4763-a8de-f342289e64c6"));

            migrationBuilder.DeleteData(
                table: "ProductSockets",
                keyColumn: "Id",
                keyValue: new Guid("2ea916a6-30fd-40b1-87e1-10f9c047e49f"));

            migrationBuilder.DeleteData(
                table: "ProductSockets",
                keyColumn: "Id",
                keyValue: new Guid("3b367888-5194-4d44-8ac9-499f381a3980"));

            migrationBuilder.DeleteData(
                table: "ProductSockets",
                keyColumn: "Id",
                keyValue: new Guid("7e231b63-30b5-4f9d-946e-cd23781c0beb"));

            migrationBuilder.DeleteData(
                table: "ProductSockets",
                keyColumn: "Id",
                keyValue: new Guid("9889871d-abd8-4e50-93e6-1294df5dd751"));

            migrationBuilder.DeleteData(
                table: "ProductSockets",
                keyColumn: "Id",
                keyValue: new Guid("d09b294f-ea4b-4478-a818-2aa3f85792f0"));

            migrationBuilder.DeleteData(
                table: "ProductSockets",
                keyColumn: "Id",
                keyValue: new Guid("d6103102-7067-4f9a-80b7-f696b0f4988a"));

            migrationBuilder.DeleteData(
                table: "ProductSockets",
                keyColumn: "Id",
                keyValue: new Guid("ee3ff4e6-56ae-4f00-ad5a-3bf135bb8802"));

            migrationBuilder.DeleteData(
                table: "PropertyValues",
                keyColumn: "Id",
                keyValue: new Guid("0ec36c53-c2d3-4694-83ca-7480cb84495e"));

            migrationBuilder.DeleteData(
                table: "PropertyValues",
                keyColumn: "Id",
                keyValue: new Guid("164d49bf-17ea-4953-b1f1-48185ada8691"));

            migrationBuilder.DeleteData(
                table: "PropertyValues",
                keyColumn: "Id",
                keyValue: new Guid("25a4799a-437c-46be-baae-1547f66ce9c2"));

            migrationBuilder.DeleteData(
                table: "PropertyValues",
                keyColumn: "Id",
                keyValue: new Guid("409b594f-a85c-4415-90a0-800232387c27"));

            migrationBuilder.DeleteData(
                table: "PropertyValues",
                keyColumn: "Id",
                keyValue: new Guid("5b0218c3-eade-4828-8b8d-e0a29132f634"));

            migrationBuilder.DeleteData(
                table: "PropertyValues",
                keyColumn: "Id",
                keyValue: new Guid("6015bcba-bebc-4353-8810-8a6d14ab8ade"));

            migrationBuilder.DeleteData(
                table: "PropertyValues",
                keyColumn: "Id",
                keyValue: new Guid("8ee761ec-cbbb-4465-913c-e92ed1187fec"));

            migrationBuilder.DeleteData(
                table: "PropertyValues",
                keyColumn: "Id",
                keyValue: new Guid("9992633b-d22b-4c2c-9593-822cc789e157"));

            migrationBuilder.DeleteData(
                table: "PropertyValues",
                keyColumn: "Id",
                keyValue: new Guid("c625d924-5b0a-4c35-a825-ada3db63a206"));

            migrationBuilder.DeleteData(
                table: "PropertyValues",
                keyColumn: "Id",
                keyValue: new Guid("e6792b58-98e5-4a6c-b90f-7446df11df05"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6381e5b5-8d60-4109-9fe8-6fcfb73e20ea"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6aee5bea-5dd9-4e03-97e2-a59ea2e6cbc2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7a97b0b5-49b3-4edc-bb95-128252180473"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("90a79691-4f7d-43b2-875c-fe44d3fcfdde"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b30a9a31-0990-46d2-b7df-10010854e382"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b782f182-3802-4ef8-8e49-f8a48f1fd8a3"));

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: new Guid("0402abd1-9d91-44e3-8207-525add7fb3b2"));

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: new Guid("32dfbae1-68df-416e-be73-0b959868b14d"));

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: new Guid("469c5262-c495-4327-b39a-129fd6a6bbd2"));

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: new Guid("d9a63b4a-d2d0-4963-b9fb-24da15622686"));

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: new Guid("ee2a6963-5ccd-4ef9-ab46-78b25f3e011e"));

            migrationBuilder.DeleteData(
                table: "Sockets",
                keyColumn: "Id",
                keyValue: new Guid("7190a380-dc61-44db-b4e1-1111c9c11d57"));

            migrationBuilder.DeleteData(
                table: "Sockets",
                keyColumn: "Id",
                keyValue: new Guid("9ebfab45-564a-45cd-b787-289fe75cf433"));

            migrationBuilder.DeleteData(
                table: "Sockets",
                keyColumn: "Id",
                keyValue: new Guid("c41c004d-0b61-4576-a732-27c1ae5b3785"));

            migrationBuilder.DeleteData(
                table: "Sockets",
                keyColumn: "Id",
                keyValue: new Guid("e48a3661-51c1-4638-87da-7d7bdf6b459f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("50382070-40b1-42e9-a22d-0c79af948cfd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("61f9f877-85b8-42b1-a5a0-ffeba89b596b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"));
        }
    }
}
