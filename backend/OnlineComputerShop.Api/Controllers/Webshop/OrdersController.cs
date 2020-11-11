using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Common.Orders;
using OnlineComputerShop.Application.Features.Webshop.Orders;

namespace OnlineComputerShop.Api.Controllers.Webshop
{
    [ApiExplorerSettings(GroupName = "webshop")]
    [Authorize("Webshop")]
    [Route("api/webshop/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public Task<IEnumerable<OrderListResponse>> ListOrders()
        {
            return mediator.Send(new OrderListQuery());
        }
        
        [HttpGet("{orderId}")]
        public Task<OrderGetResponse> GetOrder(Guid orderId)
        {
            return mediator.Send(new OrderGetQuery { OrderId = orderId });
        }
        
        [HttpPost]
        public Task CreateOrder([FromBody] OrderCreateCommand orderCreateCommand)
        {
            return mediator.Send(orderCreateCommand);
        }
    }
}
