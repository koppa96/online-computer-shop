using AutoMapper;
using OnlineComputerShop.Application.Features.Common.Products;
using OnlineComputerShop.Application.Services.Interfaces;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineComputerShop.Application.Mappings.Resolvers
{
    public class UserIdResolver : IValueResolver<object, object, Guid>
    {
        private readonly IIdentityService identityService;

        public UserIdResolver(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        public Guid Resolve(object source, object destination, Guid destMember, ResolutionContext context)
        {
            return identityService.GetUserId();
        }
    }
}
