using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Common.Orders
{
    public class OrderGetQuery : IRequest<OrderGetResponse>
    {
        public Guid OrderId { get; set; }
    }

    public class OrderGetResponse
    {
        public Guid UserName { get; set; }
        public string Address { get; set; }
        public Order.OrderState State { get; set; }

        public DateTime DateTimeOfOrder { get; set; }

        public List<OrderItemGetResponse> OrderItems { get; set; }

        public class OrderItemGetResponse
        {
            public Guid Id { get; set; }
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public int PricePerPiece { get; set; }
        }
    }

    public class GetOrderHandler : IRequestHandler<OrderGetQuery, OrderGetResponse>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public GetOrderHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<OrderGetResponse> Handle(OrderGetQuery request, CancellationToken cancellationToken)
        {
            var order = await context.Orders
                .Include(x => x.User)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                .SingleOrDefaultAsync(x => x.Id == request.OrderId);

            return mapper.Map<OrderGetResponse>(order);
        }
    }
}
