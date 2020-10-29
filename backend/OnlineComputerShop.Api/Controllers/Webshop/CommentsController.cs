using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineComputerShop.Api.Controllers.Webshop
{
    [Authorize("Webshop")]
    [Route("api/webshop/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CommentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPut("{commentId}")]
        public Task EditComment(Guid commentId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{commentId}")]
        public Task DeleteComment(Guid commentId)
        {
            throw new NotImplementedException();
        }
    }
}
