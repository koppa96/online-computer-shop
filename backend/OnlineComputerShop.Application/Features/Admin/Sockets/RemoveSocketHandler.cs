using MediatR;
using OnlineComputerShop.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Sockets
{
    public class SocketRemoveCommand : IRequest
    {
        public Guid Id { get; set; }
    }


    public class RemoveSocketHandler : IRequestHandler<SocketRemoveCommand>
    {
        private readonly OnlineComputerShopContext context;

        public RemoveSocketHandler(OnlineComputerShopContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(SocketRemoveCommand request, CancellationToken cancellationToken)
        {
            var socket = await context.Sockets.FindAsync(request.Id);
            context.Sockets.Remove(socket);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
