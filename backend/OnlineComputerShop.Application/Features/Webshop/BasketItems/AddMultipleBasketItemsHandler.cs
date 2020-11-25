using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Application.Services.Interfaces;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Application.Features.Webshop.BasketItems
{
    public class MultipleBasketItemAddCommand : IRequest
    {
        public List<BasketItemAddCommand> Commands { get; set; }
    }
    
    public class AddMultipleBasketItemsHandler : IRequestHandler<MultipleBasketItemAddCommand, Unit>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IIdentityService identityService;
        private readonly IMapper mapper;

        public AddMultipleBasketItemsHandler(
            OnlineComputerShopContext context,
            IIdentityService identityService,
            IMapper mapper)
        {
            this.context = context;
            this.identityService = identityService;
            this.mapper = mapper;
        }
        
        public async Task<Unit> Handle(MultipleBasketItemAddCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users
                .Include(x => x.BasketItems)
                .SingleOrDefaultAsync(x => x.Id == identityService.GetUserId(), cancellationToken);

            foreach (var command in request.Commands)
            {
                var existingBasketItem = user.BasketItems.SingleOrDefault(x => x.ProductId == command.ProductId);
                if (existingBasketItem == null)
                {
                    user.BasketItems.Add(mapper.Map<BasketItem>(command));
                }
                else
                {
                    existingBasketItem.Quantity += command.Quantity;
                }
            }
            
            
            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}