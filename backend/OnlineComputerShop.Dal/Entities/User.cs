using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OnlineComputerShop.Dal.Entities
{
    public class User : IdentityUser<Guid>
    {
        public virtual ICollection<OrderItem> BasketItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}