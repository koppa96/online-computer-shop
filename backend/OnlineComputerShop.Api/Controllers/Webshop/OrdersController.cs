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
        
        [HttpPost]
        public Task CreateOrder()
        {
            throw new NotImplementedException();
        }
    }
}
