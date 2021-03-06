﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Webshop.BasketItems;
using OnlineComputerShop.Dal.Entities;
using OnlineComputerShop.Dal.Exceptions;

namespace OnlineComputerShop.Api.Controllers.Webshop
{
    [ApiExplorerSettings(GroupName = "webshop")]
    [Authorize("Webshop")]
    [Route("api/webshop/basket-items")]
    [ApiController]
    public class BasketItemsController : ControllerBase
    {
        private readonly IMediator mediator;

        public BasketItemsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<BasketItemListResponse>> ListItems(CancellationToken cancellationToken)
        {
            return mediator.Send(new BasketItemListQuery(), cancellationToken);
        }

        [HttpGet("{itemId}")]
        public Task<BasketItemGetResponse> GetItem(Guid itemId, CancellationToken cancellationToken)
        {
            return mediator.Send(new BasketItemGetQuery { Id = itemId }, cancellationToken);
        }

        [HttpPost("multi")]
        public Task AddItems([FromBody] List<BasketItemAddCommand> items, CancellationToken cancellationToken)
        {
            return mediator.Send(new MultipleBasketItemAddCommand { Commands = items }, cancellationToken);
        }
        

        [HttpPost]
        public Task AddItem([FromBody] BasketItemAddCommand basketItemAddCommand, CancellationToken cancellationToken)
        {
            return mediator.Send(basketItemAddCommand, cancellationToken);
        }

        [HttpPut("{itemId}")]
        public Task EditItem(Guid itemId, [FromBody] BasketItemEditCommand basketItemEditCommand)
        {
            if (itemId != basketItemEditCommand.Id)
                throw new ValidationException("The item id's don't match.");
            return mediator.Send(basketItemEditCommand);
        }

        [HttpDelete("{itemId}")]
        public Task RemoveItem(Guid itemId)
        {
            return mediator.Send(new BasketItemRemoveCommand { Id = itemId });
        }

        [HttpDelete]
        public Task RemoveItems()
        {
            return mediator.Send(new BasketItemsRemoveCommand());
        }
    }
}
