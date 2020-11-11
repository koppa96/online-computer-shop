﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Admin.Sockets;

namespace OnlineComputerShop.Api.Controllers.Admin
{
    [ApiExplorerSettings(GroupName = "admin")]
    [Authorize("Admin")]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class SocketsController : ControllerBase
    {
        private readonly IMediator mediator;

        public SocketsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public Task CreateSocket([FromBody] SocketCreateCommand socketCreateCommand)
        {
            return mediator.Send(socketCreateCommand);
        }

        [HttpGet]
        public Task<IEnumerable<SocketListResponse>> ListSockets()
        {
            return mediator.Send(new SocketListQuery());
        }

        [HttpGet("{socketId}")]
        public Task<SocketGetResponse> GetSocket(Guid socketId)
        {
            return mediator.Send(new SocketGetQuery { Id = socketId });
        }

        [HttpDelete("{socketId}")]
        public Task RemoveSocket(Guid socketId)
        {
            return mediator.Send(new SocketRemoveCommand { Id = socketId });
        }


    }
}
