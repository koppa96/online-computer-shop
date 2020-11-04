using OnlineComputerShop.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace OnlineComputerShop.Api.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            return Guid.Parse(
                httpContextAccessor.HttpContext.User.Claims
                .SingleOrDefault(x => x.Type.ToLower() == "sub")
                .Value
            );
        }
    }
}
