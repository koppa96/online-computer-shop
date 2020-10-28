using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineComputerShop.Dal.EntityConfiguration
{
    public class PropertyValueConfiguration : IEntityTypeConfiguration<PropertyValue>
    {

        public void Configure(EntityTypeBuilder<PropertyValue> builder)
        {
            builder.HasOne(x => x.PropertyType)
                .WithMany()
                .HasForeignKey(x => x.PropertyTypeId);
        }
    }
}
