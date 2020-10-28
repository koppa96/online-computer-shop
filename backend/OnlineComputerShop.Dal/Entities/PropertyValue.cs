using System;

namespace OnlineComputerShop.Dal.Entities
{
    public class PropertyValue
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public Guid? PropertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}