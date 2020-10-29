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

        [HttpGet("{orderId}")]
        public Task GetOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{orderId}")]
        public Task EditOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{orderId}")]
        public Task DeleteOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}