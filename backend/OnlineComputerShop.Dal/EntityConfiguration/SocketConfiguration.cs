using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineComputerShop.Dal.EntityConfiguration
{
    public class SocketConfiguration : IEntityTypeConfiguration<Socket>
    {
        public void Configure(EntityTypeBuilder<Socket> builder)
        {
            builder.HasMany(x => x.CategorySockets)
                .WithOne(x => x.Socket)
                .HasForeignKey(x => x.SocketId);

            builder.HasMany(x => x.ProductSockets)
                .WithOne(x => x.Socket)
                .HasForeignKey(x => x.SocketId);
        }
    }
}
