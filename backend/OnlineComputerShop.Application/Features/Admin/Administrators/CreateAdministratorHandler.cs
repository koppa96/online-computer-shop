using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Administrators
{
    public class AdministratorCreateCommand : IRequest
    {
        public string UserName { get; set; }
    }

    public class CreateAdministratorHandler : IRequestHandler<AdministratorCreateCommand>
    {
        private readonly UserManager<User> userManager;

        public CreateAdministratorHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public Task<Unit> Handle(AdministratorCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
