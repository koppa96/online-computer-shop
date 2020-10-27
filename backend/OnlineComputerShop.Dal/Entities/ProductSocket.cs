using System;

namespace OnlineComputerShop.Dal.Entities
{
    public class ProductSocket
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid SocketId { get; set; }
        public virtual Socket Socket { get; set; }
    }
}