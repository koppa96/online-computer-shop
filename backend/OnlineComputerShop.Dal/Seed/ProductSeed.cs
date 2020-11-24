using System;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Dal.Seed
{
    public static class ProductSeed
    {
        public static Product[] Entities =
        {
            // Alaplap LGA-1150 és DDR4 foglalattal
            new Product
            {
                Id = Guid.Parse("7a97b0b5-49b3-4edc-bb95-128252180473"),
                CategoryId = Guid.Parse("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"),
                Name = "Gigabyte Z97P-D3",
                Price = 32000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis."
            },
            
            // Alaplap LGA-775 és DDR3 foglalattal
            new Product
            {
                Id = Guid.Parse("b30a9a31-0990-46d2-b7df-10010854e382"),
                CategoryId = Guid.Parse("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"),
                Name = "Gigabyte H631-X2",
                Price = 21000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis."
            },
            
            // CPU LGA-1150 foglalattal
            new Product
            {
                Id = Guid.Parse("6aee5bea-5dd9-4e03-97e2-a59ea2e6cbc2"),
                CategoryId = Guid.Parse("61f9f877-85b8-42b1-a5a0-ffeba89b596b"),
                Name = "Intel Core i5-8500",
                Price = 61000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis."
            }, 
            
            // CPU LGA-775 foglalattal
            new Product
            {
                Id = Guid.Parse("b782f182-3802-4ef8-8e49-f8a48f1fd8a3"),
                CategoryId = Guid.Parse("61f9f877-85b8-42b1-a5a0-ffeba89b596b"),
                Name = "Intel Core i3-4300",
                Price = 27000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis."
            },
            
            // Memória DDR4 foglalattal
            new Product
            {
                Id = Guid.Parse("90a79691-4f7d-43b2-875c-fe44d3fcfdde"),
                CategoryId = Guid.Parse("50382070-40b1-42e9-a22d-0c79af948cfd"),
                Name = "Kingston 8G198984135HUAA",
                Price = 20000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis."
            },
            
            // Memória DDR3 foglalattal
            new Product
            {
                Id = Guid.Parse("6381e5b5-8d60-4109-9fe8-6fcfb73e20ea"),
                CategoryId = Guid.Parse("50382070-40b1-42e9-a22d-0c79af948cfd"),
                Name = "Kinston 4G988498412333EE",
                Price = 15000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dapibus ornare erat. Morbi lacinia pellentesque molestie. Aenean finibus, ipsum eu ultrices lobortis, lorem arcu suscipit neque, vel ullamcorper leo felis at sapien. Vestibulum ut neque quis est consectetur molestie. Aliquam sed rhoncus neque, a lobortis sapien. Suspendisse euismod non lorem nec mollis. Donec et venenatis tellus. Vivamus nisl turpis, sodales sed dolor at, porta consequat erat. Mauris aliquet odio risus, sed vehicula mi porta eleifend. Nullam faucibus gravida sapien id sagittis. Suspendisse vulputate tincidunt leo ut sagittis.",
            }
        };
    }
}