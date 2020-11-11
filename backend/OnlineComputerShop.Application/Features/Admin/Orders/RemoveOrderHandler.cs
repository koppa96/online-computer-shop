using MediatR;
using OnlineComputerShop.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Orders
{
    public class OrderRemoveCommand : IRequest
    {
        public Guid Id { get; set; }

    }
    public class RemoveOrderHandler : IRequestHandler<OrderRemoveCommand>
    {
        private readonly OnlineComputerShopContext context;

        public RemoveOrderHandler(OnlineComputerShopContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(OrderRemoveCommand request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FindAsync(request.Id);
            context.Orders.Remove(order);
            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
