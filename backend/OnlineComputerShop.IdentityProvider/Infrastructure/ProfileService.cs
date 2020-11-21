using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineComputerShop.IdentityProvider.Infrastructure
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<User> userManager;

        public ProfileService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await userManager.GetUserAsync(context.Subject);
            var roles = await userManager.GetRolesAsync(user);
            if (context.RequestedClaimTypes.Any(x => x == "user_role"))
            {
                context.IssuedClaims.AddRange(roles.Select(x => new Claim("user_role", x)));
            }
            if (context.RequestedResources.ParsedScopes.Any(x => x.ParsedName == "profile"))
            {
                context.IssuedClaims.Add(new Claim("userName", user.UserName));
                context.IssuedClaims.Add(new Claim("email", user.Email));
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await userManager.GetUserAsync(context.Subject);
            context.IsActive = user != null;
        }
    }
}
