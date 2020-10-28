﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineComputerShop.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public string Foo()
        {
            return "Hello";
        }
    }
}