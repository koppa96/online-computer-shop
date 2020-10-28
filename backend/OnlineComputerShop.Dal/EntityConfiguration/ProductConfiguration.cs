using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineComputerShop.Dal.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(x => x.PropertyValues)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.ProductSockets)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
