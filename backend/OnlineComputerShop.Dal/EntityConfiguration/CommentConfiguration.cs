using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineComputerShop.Dal.Entities;
using System;

namespace OnlineComputerShop.Dal.EntityConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

        }
    }
}