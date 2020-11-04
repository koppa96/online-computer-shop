using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
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
                .SingleOrDefaultAsync(x => x.Id == request.UserId);
            if (user != null)
                context.BasketItems.RemoveRange(user.BasketItems);
            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
