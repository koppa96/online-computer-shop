using System;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Dal
{
    public class OnlineComputerShopContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public OnlineComputerShopContext(DbContextOptions<OnlineComputerShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}