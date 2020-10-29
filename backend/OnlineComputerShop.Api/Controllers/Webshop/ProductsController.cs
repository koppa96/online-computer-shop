using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineComputerShop.Api.Controllers.Webshop
{
    [Authorize("Webshop")]
    [Route("api/webshop/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{productId}")]
        public Task GetProduct(Guid productId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{productId}/comments")]
        public Task CreateComment(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
