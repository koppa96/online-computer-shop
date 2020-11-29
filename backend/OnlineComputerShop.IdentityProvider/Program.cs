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
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.IdentityProvider
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<OnlineComputerShopContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                while (true)
                {
                    try
                    {
                        await dbContext.Database.MigrateAsync();
                        break;
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, "An error occured while trying to migrate the database.");
                        await Task.Delay(3000);
                    }
                }

                var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var adminRole = new IdentityRole<Guid>("Admin");

                if (!dbContext.Roles.Any())
                {
                    await roleMgr.CreateAsync(adminRole);
                }

                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                if (!dbContext.Users.Any(x => x.UserName == configuration.GetValue<string>("DefaultAdmin:UserName")))
                {
                    var user = new User
                    {
                        UserName = configuration.GetValue<string>("DefaultAdmin:UserName"),
                        Email = configuration.GetValue<string>("DefaultAdmin:Email")
                    };
                    await userManager.CreateAsync(user, configuration.GetValue<string>("DefaultAdmin:Password"));
                    await userManager.AddToRoleAsync(user, "Admin");
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
