using AutoMapper;
using MediatR;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Sockets
{
    public class SocketEditCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class EditSocketHandler : IRequestHandler<SocketEditCommand>
    {
        private readonly OnlineComputerShopContext context;

        public EditSocketHandler(OnlineComputerShopContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(SocketEditCommand request, CancellationToken cancellationToken)
        {
            var result = await context.Sockets.FindAsync(request.Id);
            if (result == null)
            {
                throw new EntityNotFoundException();
            }
            result.Name = request.Name;
            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
