using System;

namespace OnlineComputerShop.Dal.Entities
{
    public class CategorySocket
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Guid SocketId { get; set; }
        public virtual Socket Socket { get; set; }
    }
}