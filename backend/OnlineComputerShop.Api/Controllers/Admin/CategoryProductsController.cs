using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineComputerShop.Api.Controllers.Admin
{
    [Authorize("Admin")]
    [Route("api/admin/categories/{categoryId}/products")]
    [ApiController]
    public class CategoryProductsController : ControllerBase
    {
        [HttpGet]
        public Task ListProducts(Guid categoryId)
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public Task CreateProduct(Guid categoryId)
        {
            throw new NotImplementedException();
        }
    }
}