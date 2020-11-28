using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Exceptions;
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
            var basketItem = await context.BasketItems
                .Include(x => x.Product)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (basketItem == null)
            {
                throw new EntityNotFoundException("BasketItem with requested ID is not found");
            }

            context.BasketItems.Remove(basketItem);
            basketItem.Product.Quantity += basketItem.Quantity;

            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
