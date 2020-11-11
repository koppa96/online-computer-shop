using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Application.Services.Interfaces;
using OnlineComputerShop.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Webshop.BasketItems
{
    public class BasketItemGetQuery : IRequest<BasketItemGetResponse>
    {
        public Guid Id { get; set; }
    }

    public class BasketItemGetResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int PricePerPiece { get; set; }
    }

    public class GetBasketItemHandler : IRequestHandler<BasketItemGetQuery, BasketItemGetResponse>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;

        public GetBasketItemHandler(OnlineComputerShopContext context, IMapper mapper, IIdentityService identityService)
        {
            this.context = context;
            this.mapper = mapper;
            this.identityService = identityService;
        }
        public async Task<BasketItemGetResponse> Handle(BasketItemGetQuery request, CancellationToken cancellationToken)
        {
            var item = await context.Users
                .Include(x => x.BasketItems)
                .Where(x => x.Id == identityService.GetUserId())
                .SelectMany(x => x.BasketItems)
                .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return mapper.Map<BasketItemGetResponse>(item);
        }
    }
}
