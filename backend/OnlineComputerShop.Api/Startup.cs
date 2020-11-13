using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.Processors.Security;
using OnlineComputerShop.Api.Middlewares;
using OnlineComputerShop.Api.Services;
using OnlineComputerShop.Application.Services.Interfaces;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;

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

            services.AddIdentity<User, IdentityRole<Guid>>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<OnlineComputerShopContext>();

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
            
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(Configuration.GetSection("AllowedOrigins").Get<string[]>())
                        .AllowCredentials()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            
            services.AddControllers();
            services.AddOpenApiDocument(config =>
            {
                config.Title = "OnlineComputerShop Admin API";
                config.Description = "A simple api for the administrators of a webshop selling computer parts.";
                config.DocumentName = "Admin";
                config.ApiGroupNames = new[] { "admin" };
                config.UseRouteNameAsOperationId = true;

                config.AddSecurity("OAuth2", new OpenApiSecurityScheme
                {
                    OpenIdConnectUrl =
                        $"{Configuration.GetValue<string>("Authentication:Authority")}/.well-known/openid-configuration",
                    Scheme = "Bearer",
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl =
                                $"{Configuration.GetValue<string>("Authentication:Authority")}/connect/authorize",
                            TokenUrl = $"{Configuration.GetValue<string>("Authentication:Authority")}/connect/token",
                            Scopes = new Dictionary<string, string>
                            {
                                { "adminapi.readwrite", "adminapi.readwrite" },
                                { "webshopapi.readwrite", "webshopapi.readwrite" },
                                { "openid", "openid" },
                                { "profile", "profile" }
                            }
                        }
                    }
                });

                config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("OAuth2"));
            });
            services.AddOpenApiDocument(config =>
            {
                config.Title = "OnlineComputerShop Webshop API";
                config.Description = "A simple api for the customers of a webshop selling computer parts.";
                config.DocumentName = "Webshop";
                config.ApiGroupNames = new[] { "webshop" };
                config.UseRouteNameAsOperationId = true;

                config.AddSecurity("OAuth2", new OpenApiSecurityScheme
                {
                    OpenIdConnectUrl =
                        $"{Configuration.GetValue<string>("Authentication:Authority")}/.well-known/openid-configuration",
                    Scheme = "Bearer",
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl =
                                $"{Configuration.GetValue<string>("Authentication:Authority")}/connect/authorize",
                            TokenUrl = $"{Configuration.GetValue<string>("Authentication:Authority")}/connect/token",
                            Scopes = new Dictionary<string, string>
                            {
                                { "adminapi.readwrite", "adminapi.readwrite" },
                                { "webshopapi.readwrite", "webshopapi.readwrite" },
                                { "openid", "openid" },
                                { "profile", "profile" }
                            }
                        }
                    }
                });

                config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("OAuth2"));
            });

            services.AddMediatR(Assembly.Load("OnlineComputerShop.Application"));
            services.AddAutoMapper(Assembly.Load("OnlineComputerShop.Application"));
            services.AddHttpContextAccessor();
            services.AddTransient<IIdentityService, IdentityService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseCors();
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
