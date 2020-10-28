using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.Processors.Security;
using OnlineComputerShop.Dal;

namespace OnlineComputerShop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OnlineComputerShopContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication()
                .AddJwtBearer("Admin", config =>
                {
                    config.Authority = Configuration.GetValue<string>("Authentication:Authority");
                    config.Audience = Configuration.GetValue<string>("Authentication:AdminAudience");
                })
                .AddJwtBearer("Webshop", config =>
                {
                    config.Authority = Configuration.GetValue<string>("Authentication:Authority");
                    config.Audience = Configuration.GetValue<string>("Authentication:WebshopAudience");
                });

            services.AddAuthorization(config =>
            {
                config.AddPolicy("Admin", builder => builder.RequireAuthenticatedUser()
                    .RequireClaim("scope", "adminapi.readwrite")
                    .AddAuthenticationSchemes("Admin"));
                
                config.AddPolicy("Webshop", builder => builder.RequireAuthenticatedUser()
                    .RequireClaim("scope", "webshopapi.readwrite")
                    .AddAuthenticationSchemes("Webshop"));
            });
            
            services.AddControllers();
            services.AddOpenApiDocument(config =>
            {
                config.Title = "OnlineComputerShop API";
                config.Description = "A simple api for a webshop selling computer parts.";

                config.AddSecurity("OAuth2", new OpenApiSecurityScheme
                {
                    OpenIdConnectUrl = $"{Configuration.GetValue<string>("Authentication:Authority")}/.well-known/openid-configuration",
                    Scheme = "Bearer",
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = $"{Configuration.GetValue<string>("Authentication:Authority")}/connect/authorize",
                            TokenUrl = $"{Configuration.GetValue<string>("Authentication:Authority")}/connect/token",
                            Scopes = new Dictionary<string, string>
                            {
                                { "adminapi.readwrite", "adminapi.readwrite" },
                                { "webshopapi.readwrite", "webshopapi.readwrite" },
                                { "openid", "openid" },
                                { "name", "name" }
                            }
                        }
                    }
                });
                
                config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("OAuth2"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseOpenApi();
            app.UseSwaggerUi3(config =>
            {
                config.OAuth2Client = new OAuth2ClientSettings
                {
                    ClientId = "admin",
                    ClientSecret = null,
                    UsePkceWithAuthorizationCodeGrant = true,
                    ScopeSeparator = " ",
                    Realm = null,
                    AppName = null
                };
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
