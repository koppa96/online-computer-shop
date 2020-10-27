﻿using System;

namespace OnlineComputerShop.Dal.Entities
{
    public class PropertyType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}