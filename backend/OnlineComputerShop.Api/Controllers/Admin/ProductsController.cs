using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineComputerShop.Api.Controllers.Admin
{
    [Authorize("Admin")]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{productId}")]
        public Task GetProduct(Guid productId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{productId}")]
        public Task EditProduct(Guid productId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{productId}")]
        public Task DeleteProduct(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}