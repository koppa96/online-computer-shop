using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineComputerShop.Api.Controllers
{
    [Authorize("Webshop")]
    [Route("api/[controller]")]
    [ApiController]
    public class WebshopController : ControllerBase
    {
        [HttpGet]
        public string Foo()
        {
            return "Bello";
        }
    }
}