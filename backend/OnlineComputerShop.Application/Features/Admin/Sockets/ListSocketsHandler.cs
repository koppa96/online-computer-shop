using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Sockets
{
    public class SocketListQuery : IRequest<IEnumerable<SocketListResponse>>
    {
    }

    public class SocketListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class ListSocketsHandler : IRequestHandler<SocketListQuery, IEnumerable<SocketListResponse>>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public ListSocketsHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<SocketListResponse>> Handle(SocketListQuery request, CancellationToken cancellationToken)
        {
            var sockets = await context.Sockets.ToListAsync(cancellationToken);

            return mapper.Map<List<SocketListResponse>>(sockets);
        }
    }
}
