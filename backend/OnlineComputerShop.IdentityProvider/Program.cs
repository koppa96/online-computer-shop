using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineComputerShop.Dal;

namespace OnlineComputerShop.IdentityProvider
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var services = host.Services.CreateScope())
            {
                var dbContext = services.ServiceProvider.GetRequiredService<OnlineComputerShopContext>();
                await dbContext.Database.MigrateAsync();

                var roleMgr = services.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var adminRole = new IdentityRole("Admin");

                if (!dbContext.Roles.Any())
                {
                    await roleMgr.CreateAsync(adminRole);
                }

                
               
            }            
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
