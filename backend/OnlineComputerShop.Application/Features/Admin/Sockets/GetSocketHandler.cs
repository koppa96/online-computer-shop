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
    public class SocketGetQuery : IRequest<SocketGetResponse>
    {
        public Guid Id { get; set; }
    }

    public class SocketGetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CategorySocketGetResponse> CategorySockets { get; set; }

        public class CategorySocketGetResponse
        {
            public Guid Id { get; set; }
            public Guid CategoryId { get; set; }
            public string CategoryName { get; set; }
        }

    }
    public class GetSocketHandler : IRequestHandler<SocketGetQuery, SocketGetResponse>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public GetSocketHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<SocketGetResponse> Handle(SocketGetQuery request, CancellationToken cancellationToken)
        {
            var socket = await context.Sockets
                .Include(x => x.CategorySockets)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            return mapper.Map<SocketGetResponse>(socket);
        }
    }
}
