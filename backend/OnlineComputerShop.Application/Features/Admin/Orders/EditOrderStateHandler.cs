using MediatR;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Orders
{
    public class OrderStateEditCommand : IRequest
    {
        public Guid Id { get; set; }
        public Order.OrderState State { get; set; }
    }

    public class EditOrderStateHandler : IRequestHandler<OrderStateEditCommand>
    {
        private readonly OnlineComputerShopContext context;

        public EditOrderStateHandler(OnlineComputerShopContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(OrderStateEditCommand request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FindAsync(request.Id);
            order.State = request.State;
            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
