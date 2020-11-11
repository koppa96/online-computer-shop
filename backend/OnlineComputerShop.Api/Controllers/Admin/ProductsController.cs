using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Admin.Products;
using OnlineComputerShop.Application.Features.Common.Products;

namespace OnlineComputerShop.Api.Controllers.Admin
{
    [ApiExplorerSettings(GroupName = "admin")]
    [Authorize("Admin")]
    [Route("api/admin/[controller]")]
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

        [HttpPut("{productId}")]
        public Task EditProduct(Guid productId, ProductEditCommand productEditCommand, CancellationToken cancellationToken)
        {
            if (productId != productEditCommand.Id)
                throw new Exception();
            return mediator.Send(productEditCommand, cancellationToken);
        }

        [HttpDelete("{productId}")]
        public Task RemoveProduct(Guid productId, CancellationToken cancellationToken)
        {
            return mediator.Send(new ProductRemoveCommand { ProductId = productId }, cancellationToken);
        }
    }
}