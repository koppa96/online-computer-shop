using System;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal.Entities;
using OnlineComputerShop.Dal.Seed;

namespace OnlineComputerShop.Dal
{
    public class OnlineComputerShopContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Socket> Sockets { get; set; }
        public DbSet<ProductSocket> ProductSockets { get; set; }
        public DbSet<CategorySocket> CategorySockets { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        public OnlineComputerShopContext(DbContextOptions<OnlineComputerShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            // TODO: Remove seed data before production deployment
            builder.Entity<Category>().HasData(CategorySeed.Entities);
            builder.Entity<Socket>().HasData(SocketSeed.Entities);
            builder.Entity<CategorySocket>().HasData(CategorySocketSeed.Entities);
            builder.Entity<PropertyType>().HasData(PropertyTypeSeed.Entities);
            builder.Entity<Product>().HasData(ProductSeed.Entities);
            builder.Entity<PropertyValue>().HasData(PropertyValueSeed.Entities);
            builder.Entity<ProductSocket>().HasData(ProductSocketSeed.Entities);
        }
    }
}