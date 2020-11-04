using System;
using System.Collections.Generic;
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
        public Task<IEnumerable<CategoryListResponse>> ListCategories()
        {
            return mediator.Send(new CategoryListQuery());
        }

        [HttpGet("{categoryId}")]
        public Task<CategoryGetResponse> GetCategory(Guid categoryId)
        {
            return mediator.Send(new CategoryGetQuery { Id = categoryId });
        }

        [HttpPost]
        public Task CreateCategory([FromBody] CategoryCreateCommand categoryCreateCommand)
        {
            return mediator.Send(categoryCreateCommand);
        }

        [HttpPut("{categoryId}")]
        public Task EditCategory(Guid categoryId, [FromBody] CategoryEditCommand categoryEditCommand)
        {
            if (categoryId != categoryEditCommand.Id)
                throw new Exception();
            return mediator.Send(categoryEditCommand);
        }

        [HttpDelete("{categoryId}")]
        public Task RemoveCategory(Guid categoryId)
        {
            return mediator.Send(new CategoryRemoveCommand { Id = categoryId });
        }

        [HttpGet("{categoryId}/products")]
        public Task<IEnumerable<ProductListResponse>> ListProducts(Guid categoryId, [FromQuery] List<Guid> socketIds)
        {
            return mediator.Send(new ProductListQuery { CategoryId = categoryId, SocketIds = socketIds });
        }

        [HttpPost("{categoryId}/products")]
        public Task CreateProduct(Guid categoryId, [FromBody] ProductCreateCommand productCreateCommand)
        {
            if (productCreateCommand.CategoryId != categoryId)
                throw new Exception();
            return mediator.Send(productCreateCommand);
        }
    }
}