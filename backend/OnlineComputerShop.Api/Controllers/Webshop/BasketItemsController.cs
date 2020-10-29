using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public Task ListItems()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task AddItem()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{itemId}")]
        public Task EditItem(Guid itemId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{itemId}")]
        public Task RemoveItem(Guid itemId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public Task RemoveItems()
        {
            throw new NotImplementedException();
        }
    }
}
