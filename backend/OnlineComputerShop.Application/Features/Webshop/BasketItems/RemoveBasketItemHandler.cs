using MediatR;
using OnlineComputerShop.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Webshop.BasketItems
{
    public class BasketItemRemoveCommand : IRequest
    {
        public Guid Id { get; set; }
    }


    public class RemoveBasketItemHandler : IRequestHandler<BasketItemRemoveCommand>
    {
        private readonly OnlineComputerShopContext context;

        public RemoveBasketItemHandler(OnlineComputerShopContext context)
        {
            this.context = context;
        }


        public async Task<Unit> Handle(BasketItemRemoveCommand request, CancellationToken cancellationToken)
        {
            var item = await context.OrderItems.FindAsync(request.Id);
            if (item != null)
                context.OrderItems.Remove(item);
            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
