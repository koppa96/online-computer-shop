using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Webshop.BasketItems;

namespace OnlineComputerShop.Api.Controllers.Webshop
{
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
        public Task<IEnumerable<BasketItemListResponse>> ListItems()
        {
            return mediator.Send(new BasketItemListQuery());
        }

        [HttpGet("{itemId}")]
        public Task<BasketItemGetResponse> GetItem(Guid itemId)
        {
            return mediator.Send(new BasketItemGetQuery { Id = itemId });
        }

        [HttpPost]
        public Task AddItem([FromBody] BasketItemAddCommand basketItemAddCommand)
        {
            return mediator.Send(basketItemAddCommand);
        }

        [HttpPut("{itemId}")]
        public Task EditItem(Guid itemId, [FromBody] BasketItemEditCommand basketItemEditCommand)
        {
            if (itemId != basketItemEditCommand.Id)
                throw new Exception();
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
