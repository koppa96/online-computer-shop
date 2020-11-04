using System;

namespace OnlineComputerShop.Dal.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public int PricePerPiece { get; set; }
    }
}