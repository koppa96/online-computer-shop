using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineComputerShop.Dal.Entities
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
