using System;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Dal.Seed
{
    public static class CategorySocketSeed
    {
        public static CategorySocket[] Entities { get; } =
        {
            // ALAPLAPOK
            new CategorySocket
            {
                Id = Guid.Parse("bcd10130-ba36-4f5e-b93a-cd5b557adae8"),
                CategoryId = Guid.Parse("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"),
                SocketId = Guid.Parse("e48a3661-51c1-4638-87da-7d7bdf6b459f")
            },
            new CategorySocket
            {
                Id = Guid.Parse("b1893112-fea5-46fb-9d08-3bfdc5ac4284"),
                CategoryId = Guid.Parse("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"),
                SocketId = Guid.Parse("7190a380-dc61-44db-b4e1-1111c9c11d57")
            },
            new CategorySocket
            {
                Id = Guid.Parse("5a2ed25d-8d27-4b2f-946d-80b81102f10a"),
                CategoryId = Guid.Parse("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"),
                SocketId = Guid.Parse("9ebfab45-564a-45cd-b787-289fe75cf433")
            },
            new CategorySocket
            {
                Id = Guid.Parse("136a1f85-f331-46f0-85f8-53a578edbc6c"),
                CategoryId = Guid.Parse("f1ffa7f0-4e91-4ec7-929f-0d8d41ee06c9"),
                SocketId = Guid.Parse("c41c004d-0b61-4576-a732-27c1ae5b3785")
            },
            
            // PROCESSZOROK
            new CategorySocket
            {
                Id = Guid.Parse("dbaa3025-fbee-4bed-83d1-daaf7bb5b1ce"),
                CategoryId = Guid.Parse("61f9f877-85b8-42b1-a5a0-ffeba89b596b"),
                SocketId = Guid.Parse("e48a3661-51c1-4638-87da-7d7bdf6b459f")
            },
            new CategorySocket
            {
                Id = Guid.Parse("bcb1475d-34f3-4c15-a418-a57c19913bcf"),
                CategoryId = Guid.Parse("61f9f877-85b8-42b1-a5a0-ffeba89b596b"),
                SocketId = Guid.Parse("7190a380-dc61-44db-b4e1-1111c9c11d57")
            },
            
            // MEMÓRIÁK
            new CategorySocket
            {
                Id = Guid.Parse("91f6300a-53fa-4f48-8f94-8f4c2b253e54"),
                CategoryId = Guid.Parse("50382070-40b1-42e9-a22d-0c79af948cfd"),
                SocketId = Guid.Parse("9ebfab45-564a-45cd-b787-289fe75cf433")
            },
            new CategorySocket
            {
                Id = Guid.Parse("724e0f4b-7097-4c1d-adce-add2da917608"),
                CategoryId = Guid.Parse("50382070-40b1-42e9-a22d-0c79af948cfd"),
                SocketId = Guid.Parse("c41c004d-0b61-4576-a732-27c1ae5b3785")
            },
        };
    }
}