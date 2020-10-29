using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineComputerShop.Api.Controllers.Admin
{
    [Authorize("Admin")]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public Task ListOrders()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task GetOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task EditOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task DeleteOrder(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}