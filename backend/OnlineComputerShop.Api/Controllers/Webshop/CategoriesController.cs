using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Common.Categories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineComputerShop.Api.Controllers.Webshop
{
    [Authorize("Webshop")]
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
        public Task<IEnumerable<CategoryListResponse>> ListCategories()
        {
            return mediator.Send(new CategoryListQuery());
        }

        [HttpGet("{categoryId}/products")]
        public Task ListProducts(Guid categoryId, [FromQuery] List<Guid> socketIds)
        {
            throw new NotImplementedException();
        }
    }
}
