using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Administrators
{
    public class AdministratorRemoveCommand : IRequest
    {
        public string UserName { get; set; }
    }

    public class RemoveAdministratorHandler : IRequestHandler<AdministratorRemoveCommand>
    {
        private readonly UserManager<User> userManager;

        public RemoveAdministratorHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(AdministratorRemoveCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            await userManager.RemoveFromRoleAsync(user, "Admin");
            return Unit.Value;
        }
    }
}
