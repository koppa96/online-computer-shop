using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Common.Comments;
using OnlineComputerShop.Application.Features.Webshop.Comments;

namespace OnlineComputerShop.Api.Controllers.Webshop
{
    [ApiExplorerSettings(GroupName = "webshop")]
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
        public Task EditComment(Guid commentId, [FromBody] CommentEditCommand commentEditCommand)
        {
            if (commentId != commentEditCommand.Id)
                throw new Exception();

            return mediator.Send(commentEditCommand);
        }

        [HttpDelete("{commentId}")]
        public Task RemoveComment(Guid commentId)
        {
            return mediator.Send(new CommentRemoveCommand
            {
                Id = commentId
            });
        }
    }
}
