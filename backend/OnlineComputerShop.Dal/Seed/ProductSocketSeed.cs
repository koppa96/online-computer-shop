using System;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Dal.Seed
{
    public static class ProductSocketSeed
    {
        public static ProductSocket[] Entities =
        {
            // Alaplap LGA-1150 és DDR4 foglalattal
            new ProductSocket
            {
                Id = Guid.Parse("d6103102-7067-4f9a-80b7-f696b0f4988a"),
                ProductId = Guid.Parse("7a97b0b5-49b3-4edc-bb95-128252180473"),
                SocketId = Guid.Parse("e48a3661-51c1-4638-87da-7d7bdf6b459f"),
                ProvidesUses = ProvidesUses.Provides,
                NumberOfSocket = 1
            },
            new ProductSocket
            {
                Id = Guid.Parse("9889871d-abd8-4e50-93e6-1294df5dd751"),
                ProductId = Guid.Parse("7a97b0b5-49b3-4edc-bb95-128252180473"),
                SocketId = Guid.Parse("9ebfab45-564a-45cd-b787-289fe75cf433"),
                ProvidesUses = ProvidesUses.Provides,
                NumberOfSocket = 1
            },
            
            // Alaplap LGA-775 és DDR3 foglalattal
            new ProductSocket
            {
                Id = Guid.Parse("3b367888-5194-4d44-8ac9-499f381a3980"),
                ProductId = Guid.Parse("b30a9a31-0990-46d2-b7df-10010854e382"),
                SocketId = Guid.Parse("7190a380-dc61-44db-b4e1-1111c9c11d57"),
                ProvidesUses = ProvidesUses.Provides,
                NumberOfSocket = 1
            }, 
            new ProductSocket
            {
                Id = Guid.Parse("ee3ff4e6-56ae-4f00-ad5a-3bf135bb8802"),
                ProductId = Guid.Parse("b30a9a31-0990-46d2-b7df-10010854e382"),
                SocketId = Guid.Parse("c41c004d-0b61-4576-a732-27c1ae5b3785"),
                ProvidesUses = ProvidesUses.Provides,
                NumberOfSocket = 1
            },
            
            // Processzor LGA-1150 foglalattal
            new ProductSocket
            {
                Id = Guid.Parse("2ea916a6-30fd-40b1-87e1-10f9c047e49f"),
                ProductId = Guid.Parse("6aee5bea-5dd9-4e03-97e2-a59ea2e6cbc2"),
                SocketId = Guid.Parse("e48a3661-51c1-4638-87da-7d7bdf6b459f"),
                ProvidesUses = ProvidesUses.Uses,
                NumberOfSocket = 1
            }, 
            
            // Processzor LGA-775 foglalattal
            new ProductSocket
            {
                Id = Guid.Parse("7e231b63-30b5-4f9d-946e-cd23781c0beb"),
                ProductId = Guid.Parse("b782f182-3802-4ef8-8e49-f8a48f1fd8a3"),
                SocketId = Guid.Parse("7190a380-dc61-44db-b4e1-1111c9c11d57"),
                ProvidesUses = ProvidesUses.Uses,
                NumberOfSocket = 1
            }, 
            
            // Memória DDR4 foglalattal
            new ProductSocket
            {
                Id = Guid.Parse("1f3f2462-8dc1-4763-a8de-f342289e64c6"),
                ProductId = Guid.Parse("90a79691-4f7d-43b2-875c-fe44d3fcfdde"),
                SocketId = Guid.Parse("9ebfab45-564a-45cd-b787-289fe75cf433"),
                ProvidesUses = ProvidesUses.Uses,
                NumberOfSocket = 1
            }, 
            
            // Memória DDR3 foglalattal
            new ProductSocket
            {
                Id = Guid.Parse("d09b294f-ea4b-4478-a818-2aa3f85792f0"),
                ProductId = Guid.Parse("6381e5b5-8d60-4109-9fe8-6fcfb73e20ea"),
                SocketId = Guid.Parse("c41c004d-0b61-4576-a732-27c1ae5b3785"),
                ProvidesUses = ProvidesUses.Uses,
                NumberOfSocket = 1
            }, 
        };
    }
}