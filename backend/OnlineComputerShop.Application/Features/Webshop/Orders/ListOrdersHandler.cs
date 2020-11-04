using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Application.Services.Interfaces;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Webshop.Orders
{
    public class OrderListQuery : IRequest<IEnumerable<OrderListResponse>>
    {
    }

    public class OrderListResponse
    {
        public Guid Id { get; set; }
        public Order.OrderState State { get; set; }
        public DateTime DateTimeOfOrder { get; set; }
    }
    public class ListOrdersHandler : IRequestHandler<OrderListQuery, IEnumerable<OrderListResponse>>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;

        public ListOrdersHandler(OnlineComputerShopContext context, IMapper mapper, IIdentityService identityService)
        {
            this.context = context;
            this.mapper = mapper;
            this.identityService = identityService;
        }
        public async Task<IEnumerable<OrderListResponse>> Handle(OrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await context.Orders
                .Where(x => x.UserId == identityService.GetUserId())
                .ToListAsync(cancellationToken);
            return mapper.Map<List<OrderListResponse>>(orders);
        }
    }
}
