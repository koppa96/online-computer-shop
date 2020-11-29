using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Application.Services.Interfaces;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using OnlineComputerShop.Dal.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Webshop.BasketItems
{
    public class BasketItemEditCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }


    }
    public class EditBasketItemHandler : IRequestHandler<BasketItemEditCommand>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;

        public EditBasketItemHandler(OnlineComputerShopContext context, IMapper mapper, IIdentityService identityService)
        {
            this.context = context;
            this.mapper = mapper;
            this.identityService = identityService;
        }
        public async Task<Unit> Handle(BasketItemEditCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users
                .Include(x => x.BasketItems)
                    .ThenInclude(x => x.Product)
                .SingleOrDefaultAsync(x => x.Id == identityService.GetUserId(), cancellationToken);
            var basketItem = user.BasketItems
                .SingleOrDefault(x => x.Id == request.Id);

            if (basketItem == null)
            {
                user.BasketItems.Add(mapper.Map<BasketItem>(request));
            }
            else
            {
                if (basketItem.ProductId != request.ProductId)
                {
                    throw new ValidationException();
                }
                if ((request.Quantity - basketItem.Quantity) > basketItem.Product.Quantity)
                {
                    throw new ValidationException();
                }
                basketItem.Product.Quantity += (basketItem.Quantity - request.Quantity);
                basketItem.Quantity = request.Quantity;
                if (basketItem.Quantity == 0)
                {
                    context.BasketItems.Remove(basketItem);
                }
            }

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
