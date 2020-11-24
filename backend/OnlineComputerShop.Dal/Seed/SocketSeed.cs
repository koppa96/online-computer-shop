using System;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Dal.Seed
{
    public static class SocketSeed
    {
        public static Socket[] Entities { get; } =
        {
            new Socket
            {
                Id = Guid.Parse("e48a3661-51c1-4638-87da-7d7bdf6b459f"),
                Name = "LGA-1150"
            },
            new Socket
            {
                Id = Guid.Parse("7190a380-dc61-44db-b4e1-1111c9c11d57"),
                Name = "LGA-775"
            },
            new Socket
            {
                Id = Guid.Parse("9ebfab45-564a-45cd-b787-289fe75cf433"),
                Name = "DDR4"
            },
            new Socket
            {
                Id = Guid.Parse("c41c004d-0b61-4576-a732-27c1ae5b3785"),
                Name = "DDR3"
            }
        };
    }
}