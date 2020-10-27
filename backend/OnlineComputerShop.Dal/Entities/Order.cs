using System;
using System.Collections.Generic;

namespace OnlineComputerShop.Dal.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}