using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineComputerShop.Dal.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.CategorySockets)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.PropertyTypes)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
