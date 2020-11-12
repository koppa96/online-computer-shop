using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Common.Categories;
using OnlineComputerShop.Application.Features.Common.Products;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Api.Controllers.Webshop
{
    [ApiExplorerSettings(GroupName = "webshop")]
    [Route("api/webshop/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet]
        public Task<IEnumerable<CategoryListResponse>> ListCategories(CancellationToken cancellationToken)
        {
            return mediator.Send(new CategoryListQuery(), cancellationToken);
        }

        [HttpGet("{categoryId}/products")]
        public Task<IEnumerable<ProductListResponse>> ListProducts(Guid categoryId, [FromQuery] List<Guid> socketIds, CancellationToken cancellationToken)
        {
            return mediator.Send(new ProductListQuery
            { 
                CategoryId = categoryId,
                SocketIds = socketIds
            }, cancellationToken);
        }
    }
}
