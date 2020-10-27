using System;
using System.Collections.Generic;

namespace OnlineComputerShop.Dal.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PropertyType> PropertyTypes { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<CategorySocket> CategorySockets { get; set; }
    }
}