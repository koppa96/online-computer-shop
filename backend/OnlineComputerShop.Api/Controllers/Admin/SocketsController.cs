using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public Task CreateSocket([FromBody] SocketCreateCommand socketCreateCommand, CancellationToken cancellationToken)
        {
            return mediator.Send(socketCreateCommand, cancellationToken);
        }

        [HttpGet]
        public Task<IEnumerable<SocketListResponse>> ListSockets(CancellationToken cancellationToken)
        {
            return mediator.Send(new SocketListQuery(), cancellationToken);
        }

        [HttpGet("{socketId}")]
        public Task<SocketGetResponse> GetSocket(Guid socketId, CancellationToken cancellationToken)
        {
            return mediator.Send(new SocketGetQuery { Id = socketId }, cancellationToken);
        }

        [HttpDelete("{socketId}")]
        public Task RemoveSocket(Guid socketId, CancellationToken cancellationToken)
        {
            return mediator.Send(new SocketRemoveCommand { Id = socketId }, cancellationToken);
        }

        [HttpPut("{socketId}")]
        public Task EditSocket(Guid socketId, [FromBody] SocketEditCommand socketEditCommand, CancellationToken cancellationToken)
        {
            if (socketId != socketEditCommand.Id)
            {
                throw new Exception();
            }

            return mediator.Send(socketEditCommand, cancellationToken);
        }


    }
}
