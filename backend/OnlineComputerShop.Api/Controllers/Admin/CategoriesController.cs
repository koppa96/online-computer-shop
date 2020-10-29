using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Admin.Categories;

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

        [HttpGet("{id}")]
        public Task GetCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task CreateCategory()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task EditCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}