using AutoMapper;
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

namespace OnlineComputerShop.Application.Features.Admin.Orders
{
    public class OrderListQuery : IRequest<IEnumerable<OrderListResponse>>
    {
        public string UserName { get; set; }
    }

    public class OrderListResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public Order.OrderState State { get; set; }
        public DateTime DateTimeOfOrder { get; set; }
    }
    public class ListOrdersHandler : IRequestHandler<OrderListQuery, IEnumerable<OrderListResponse>>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public ListOrdersHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<OrderListResponse>> Handle(OrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await context.Orders
                .Include(x => x.User)
                .Where(x => x.User.UserName == request.UserName)
                .ToListAsync();
            return mapper.Map<List<OrderListResponse>>(orders);
        }
    }
}
