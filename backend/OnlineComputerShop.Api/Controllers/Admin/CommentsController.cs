﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Common.Comments;

namespace OnlineComputerShop.Api.Controllers.Admin
{
    [Authorize("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CommentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpDelete("{commentId}")]
        public Task RemoveComment(Guid commentId)
        {
            return mediator.Send(new CommentRemoveCommand { Id = commentId });
        }


    }
}
