using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Common.Products;
using OnlineComputerShop.Application.Features.Webshop.Products;
using OnlineComputerShop.Application.Services.Interfaces;

namespace OnlineComputerShop.Api.Controllers.Webshop
{
    [ApiExplorerSettings(GroupName = "webshop")]
    [Route("api/webshop/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet("{productId}")]
        public Task<ProductGetResponse> GetProduct(Guid productId, CancellationToken cancellationToken)
        {
            return mediator.Send(new ProductGetQuery { ProductId = productId }, cancellationToken);
        }

        [HttpPost("{productId}/comments")]
        [Authorize("Webshop")]
        public Task CreateComment([FromBody] CommentCreateCommand commentCreateCommand, CancellationToken cancellationToken)
        {
            return mediator.Send(commentCreateCommand, cancellationToken);
        }
    }
}
