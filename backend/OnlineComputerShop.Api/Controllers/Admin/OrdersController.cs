using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Admin.Orders;
using OnlineComputerShop.Application.Features.Common.Orders;

namespace OnlineComputerShop.Api.Controllers.Admin
{
    [ApiExplorerSettings(GroupName = "admin")]
    [Authorize("Admin")]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public Task<IEnumerable<OrderListResponse>> ListOrders([FromQuery] string userName, CancellationToken cancellationToken)
        {
            return mediator.Send(new OrderListQuery { UserName = userName }, cancellationToken);
        }

        [HttpGet("{orderId}")]
        public Task<OrderGetResponse> GetOrder(Guid orderId, CancellationToken cancellationToken)
        {
            return mediator.Send(new OrderGetQuery { OrderId = orderId }, cancellationToken);
        }

        [HttpPut("{orderId}/state")]
        public Task EditOrderState(Guid orderId, [FromBody] OrderStateEditCommand orderStateEditCommand, CancellationToken cancellationToken)
        {
            if (orderId != orderStateEditCommand.Id)
                throw new Exception();
            return mediator.Send(orderStateEditCommand, cancellationToken);
        }

        [HttpPut("{orderId}/address")]
        public Task EditOrderAddress(Guid orderId, [FromBody] OrderAddressEditCommand orderAddressEditCommand, CancellationToken cancellationToken)
        {
            if (orderId != orderAddressEditCommand.Id)
                throw new Exception();
            return mediator.Send(orderAddressEditCommand, cancellationToken);
        }


        [HttpDelete("{orderId}")]
        public Task RemoveOrder(Guid orderId, CancellationToken cancellationToken)
        {
            return mediator.Send(new OrderRemoveCommand { Id = orderId }, cancellationToken);
        }
    }
}