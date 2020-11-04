using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineComputerShop.Dal.EntityConfiguration
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);
        }
    }

}
