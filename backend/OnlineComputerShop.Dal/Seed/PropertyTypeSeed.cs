using System;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Dal.Seed
{
    public static class PropertyTypeSeed
    {
        public static PropertyType[] Entities { get; } =
        {
            new PropertyType
            {
                Id = Guid.Parse("d9a63b4a-d2d0-4963-b9fb-24da15622686"),
                CategoryId = Guid.Parse("61f9f877-85b8-42b1-a5a0-ffeba89b596b"),
                Name = "Órajel"
            },
            new PropertyType
            {
                Id = Guid.Parse("469c5262-c495-4327-b39a-129fd6a6bbd2"),
                CategoryId = Guid.Parse("61f9f877-85b8-42b1-a5a0-ffeba89b596b"),
                Name = "Magok száma"
            },
            new PropertyType
            {
                Id = Guid.Parse("32dfbae1-68df-416e-be73-0b959868b14d"),
                CategoryId = Guid.Parse("61f9f877-85b8-42b1-a5a0-ffeba89b596b"),
                Name = "Szálak száma"
            },
            new PropertyType
            {
                Id = Guid.Parse("0402abd1-9d91-44e3-8207-525add7fb3b2"),
                CategoryId = Guid.Parse("50382070-40b1-42e9-a22d-0c79af948cfd"),
                Name = "Méret"
            },
            new PropertyType
            {
                Id = Guid.Parse("ee2a6963-5ccd-4ef9-ab46-78b25f3e011e"),
                CategoryId = Guid.Parse("50382070-40b1-42e9-a22d-0c79af948cfd"),
                Name = "Frekvencia"
            }
        };
    }
}