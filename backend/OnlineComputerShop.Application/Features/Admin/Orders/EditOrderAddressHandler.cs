using AutoMapper;
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
    public class OrderAddressEditCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
    }

    public class EditOrderAddressHandler : IRequestHandler<OrderAddressEditCommand>
    {
        private readonly OnlineComputerShopContext context;

        public EditOrderAddressHandler(OnlineComputerShopContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(OrderAddressEditCommand request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FindAsync(request.Id);
            
            if (order.State != Order.OrderState.Unsent)
                return Unit.Value;
            
            order.Address = request.Address;
            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
