using System;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Dal.Seed
{
    public static class CategorySeed
    {
        public static Category[] Entities { get; } =
        {
            new Category
            {
                Id = Guid.Parse("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"),
                Name = "Alaplapok"
            },
            new Category
            {
                Id = Guid.Parse("61f9f877-85b8-42b1-a5a0-ffeba89b596b"),
                Name = "Processzorok"
            },
            new Category
            {
                Id = Guid.Parse("50382070-40b1-42e9-a22d-0c79af948cfd"),
                Name = "Memóriák"
            }
        };
    }
}