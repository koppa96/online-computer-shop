using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Common.Categories;

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
        public Task GetCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task CreateCategory()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{categoryId}")]
        public Task EditCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{categoryId}")]
        public Task DeleteCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{categoryId}/products")]
        public Task ListProducts(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{categoryId}/products")]
        public Task CreateProduct(Guid categoryId)
        {
            throw new NotImplementedException();
        }
    }
}