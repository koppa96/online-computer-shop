using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Admin.Categories;
using OnlineComputerShop.Application.Features.Admin.Products;
using OnlineComputerShop.Application.Features.Common.Categories;
using OnlineComputerShop.Application.Features.Common.Products;

namespace OnlineComputerShop.Api.Controllers.Admin
{
    [ApiExplorerSettings(GroupName = "admin")]
    [Authorize("Admin")]
    [Route("api/admin/[controller]")]
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

        [HttpGet("{categoryId}")]
        public Task<CategoryGetResponse> GetCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            return mediator.Send(new CategoryGetQuery { Id = categoryId }, cancellationToken);
        }

        [HttpPost]
        public Task CreateCategory([FromBody] CategoryCreateCommand categoryCreateCommand, CancellationToken cancellationToken)
        {
            return mediator.Send(categoryCreateCommand, cancellationToken);
        }

        [HttpPut("{categoryId}")]
        public Task EditCategory(Guid categoryId, [FromBody] CategoryEditCommand categoryEditCommand, CancellationToken cancellationToken)
        {
            if (categoryId != categoryEditCommand.Id)
                throw new Exception();
            return mediator.Send(categoryEditCommand, cancellationToken);
        }

        [HttpDelete("{categoryId}")]
        public Task RemoveCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            return mediator.Send(new CategoryRemoveCommand { Id = categoryId }, cancellationToken);
        }

        [HttpGet("{categoryId}/products")]
        public Task<IEnumerable<ProductListResponse>> ListProducts(Guid categoryId, CancellationToken cancellationToken)
        {
            return mediator.Send(new ProductListQuery { CategoryId = categoryId }, cancellationToken);
        }

        [HttpPost("{categoryId}/products")]
        public Task CreateProduct(Guid categoryId, [FromBody] ProductCreateCommand productCreateCommand, CancellationToken cancellationToken)
        {
            if (productCreateCommand.CategoryId != categoryId)
                throw new Exception();
            return mediator.Send(productCreateCommand, cancellationToken);
        }
    }
}