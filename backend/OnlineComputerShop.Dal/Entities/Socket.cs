using System;
using System.Collections.Generic;

namespace OnlineComputerShop.Dal.Entities
{
    public class Socket
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CategorySocket> CategorySockets { get; set; }
        public virtual ICollection<ProductSocket> ProductSockets { get; set; }
    }
}