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

    public class BasketItemListQuery : IRequest<IEnumerable<BasketItemListResponse>>
    {
    }

    public class BasketItemListResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int PricePerPiece { get; set; }

    }

    public class ListBasketItemsHandler : IRequestHandler<BasketItemListQuery, IEnumerable<BasketItemListResponse>>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;

        public ListBasketItemsHandler(OnlineComputerShopContext context, IMapper mapper, IIdentityService identityService)
        {
            this.context = context;
            this.mapper = mapper;
            this.identityService = identityService;
        }

        public async Task<IEnumerable<BasketItemListResponse>> Handle(BasketItemListQuery request, CancellationToken cancellationToken)
        {
            var items = await context.BasketItems
                .Where(x => x.UserId == identityService.GetUserId())
                .ToListAsync(cancellationToken);

            return mapper.Map<List<BasketItemListResponse>>(items);
        }
    }
}
