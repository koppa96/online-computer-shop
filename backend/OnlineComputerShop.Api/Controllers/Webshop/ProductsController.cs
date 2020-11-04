using System;
using System.Linq;
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
    [Authorize("Webshop")]
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
        public Task<ProductGetResponse> GetProduct(Guid productId)
        {
            return mediator.Send(new ProductGetQuery { ProductId = productId });
        }

        [HttpPost("{productId}/comments")]
        public Task CreateComment([FromBody] CommentCreateCommand commentCreateCommand)
        {
            return mediator.Send(commentCreateCommand);
        }
    }
}
