using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using OnlineComputerShop.Dal.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Webshop.BasketItems
{
    public class BasketItemsRemoveCommand : IRequest
    {
        public Guid UserId { get; set; }
    }
    public class RemoveBasketItemsHandler : IRequestHandler<BasketItemsRemoveCommand>
    {
        private readonly OnlineComputerShopContext context;

        public RemoveBasketItemsHandler(OnlineComputerShopContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(BasketItemsRemoveCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users
                .Include(x => x.BasketItems)
                    .ThenInclude(x => x.Product)
                .SingleOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            if (user == null)
            {
                throw new EntityNotFoundException("User not found");
            }

            context.BasketItems.RemoveRange(user.BasketItems);
            foreach (var item in user.BasketItems)
            {
                item.Product.Quantity += item.Quantity;
            }

            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
