using System;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Dal.Seed
{
    public static class PropertyValueSeed
    {
        public static PropertyValue[] Entities { get; } =
        {
            // Processzor LGA-1150 foglalattal
            new PropertyValue
            {
                Id = Guid.Parse("0ec36c53-c2d3-4694-83ca-7480cb84495e"),
                ProductId = Guid.Parse("7a97b0b5-49b3-4edc-bb95-128252180473"),
                PropertyTypeId = Guid.Parse("d9a63b4a-d2d0-4963-b9fb-24da15622686"),
                Value = "3.80Ghz"
            },
            new PropertyValue
            {
                Id = Guid.Parse("8ee761ec-cbbb-4465-913c-e92ed1187fec"),
                ProductId = Guid.Parse("7a97b0b5-49b3-4edc-bb95-128252180473"),
                PropertyTypeId = Guid.Parse("469c5262-c495-4327-b39a-129fd6a6bbd2"),
                Value = "4"
            },
            new PropertyValue
            {
                Id = Guid.Parse("6015bcba-bebc-4353-8810-8a6d14ab8ade"),
                ProductId = Guid.Parse("7a97b0b5-49b3-4edc-bb95-128252180473"),
                PropertyTypeId = Guid.Parse("32dfbae1-68df-416e-be73-0b959868b14d"),
                Value = "8"
            },
            
            // Processzor LGA-775 foglalattal
            new PropertyValue
            {
                Id = Guid.Parse("5b0218c3-eade-4828-8b8d-e0a29132f634"),
                ProductId = Guid.Parse("b782f182-3802-4ef8-8e49-f8a48f1fd8a3"),
                PropertyTypeId = Guid.Parse("d9a63b4a-d2d0-4963-b9fb-24da15622686"),
                Value = "3.40Ghz"
            },
            new PropertyValue
            {
                Id = Guid.Parse("25a4799a-437c-46be-baae-1547f66ce9c2"),
                ProductId = Guid.Parse("b782f182-3802-4ef8-8e49-f8a48f1fd8a3"),
                PropertyTypeId = Guid.Parse("469c5262-c495-4327-b39a-129fd6a6bbd2"),
                Value = "4"
            },
            new PropertyValue
            {
                Id = Guid.Parse("9992633b-d22b-4c2c-9593-822cc789e157"),
                ProductId = Guid.Parse("b782f182-3802-4ef8-8e49-f8a48f1fd8a3"),
                PropertyTypeId = Guid.Parse("32dfbae1-68df-416e-be73-0b959868b14d"),
                Value = "4"
            },
            
            // Memória DDR4 foglalattal
            new PropertyValue
            {
                Id = Guid.Parse("e6792b58-98e5-4a6c-b90f-7446df11df05"),
                ProductId = Guid.Parse("90a79691-4f7d-43b2-875c-fe44d3fcfdde"),
                PropertyTypeId = Guid.Parse("0402abd1-9d91-44e3-8207-525add7fb3b2"),
                Value = "8GB"
            },
            new PropertyValue
            {
                Id = Guid.Parse("409b594f-a85c-4415-90a0-800232387c27"),
                ProductId = Guid.Parse("90a79691-4f7d-43b2-875c-fe44d3fcfdde"),
                PropertyTypeId = Guid.Parse("ee2a6963-5ccd-4ef9-ab46-78b25f3e011e"),
                Value = "3200Mhz"
            },
            
            // Memória DDR3 foglalattal
            new PropertyValue
            {
                Id = Guid.Parse("164d49bf-17ea-4953-b1f1-48185ada8691"),
                ProductId = Guid.Parse("6381e5b5-8d60-4109-9fe8-6fcfb73e20ea"),
                PropertyTypeId = Guid.Parse("0402abd1-9d91-44e3-8207-525add7fb3b2"),
                Value = "4GB"
            },
            new PropertyValue
            {
                Id = Guid.Parse("c625d924-5b0a-4c35-a825-ada3db63a206"),
                ProductId = Guid.Parse("6381e5b5-8d60-4109-9fe8-6fcfb73e20ea"),
                PropertyTypeId = Guid.Parse("ee2a6963-5ccd-4ef9-ab46-78b25f3e011e"),
                Value = "1600Mhz"
            }
        };
    }
}