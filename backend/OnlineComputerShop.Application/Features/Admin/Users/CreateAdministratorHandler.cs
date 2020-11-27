using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal.Entities;
using OnlineComputerShop.Dal.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Users
{
    public class AdministratorCreateCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class CreateAdministratorHandler : IRequestHandler<AdministratorCreateCommand>
    {
        private readonly UserManager<User> userManager;

        public CreateAdministratorHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(AdministratorCreateCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
            {
                throw new EntityNotFoundException("User with the given ID is not found");
            }
            await userManager.AddToRoleAsync(user, "Admin");
            return Unit.Value;

        }
    }
}
