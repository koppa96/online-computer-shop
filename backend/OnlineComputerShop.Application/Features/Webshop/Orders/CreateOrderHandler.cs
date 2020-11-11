using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Application.Services.Interfaces;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Webshop.Orders
{
    public class OrderCreateCommand : IRequest
    {
        public string Address { get; set; }
    }
    public class CreateOrderHandler : IRequestHandler<OrderCreateCommand>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IIdentityService identityService;

        public CreateOrderHandler(OnlineComputerShopContext context, IIdentityService identityService)
        {
            this.context = context;
            this.identityService = identityService;
        }
        public async Task<Unit> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var userId = identityService.GetUserId();
            
            var basketItems = await context.BasketItems
                .Include(x => x.Product)
                .Where(x => x.UserId == userId)
                .ToListAsync(cancellationToken);
            
            var orderItems = basketItems.Select(x =>
                    new OrderItem
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        PricePerPiece = x.Product.Price
                    }
                ).ToList();
            
            var order = new Order
            {
                UserId = userId,
                OrderItems = orderItems,
                Address = request.Address,
                State = Order.OrderState.Unsent,
                DateTimeOfOrder = DateTime.UtcNow
            };
            
            context.Orders.Add(order);
            context.BasketItems.RemoveRange(basketItems);
            await context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
