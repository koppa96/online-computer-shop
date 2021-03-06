﻿using System;
using System.Collections.Generic;

namespace OnlineComputerShop.Dal.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<PropertyValue> PropertyValues { get; set; }
        public virtual ICollection<ProductSocket> ProductSockets { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}