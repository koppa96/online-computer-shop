using AutoMapper;
using MediatR;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Sockets
{
    public class SocketCreateCommand : IRequest
    {
        public string Name { get; set; }
        public List<CategorySocketCreateCommand> CategorySockets { get; set; }

        public class CategorySocketCreateCommand
        {
            public Guid CategoryId { get; set; }
        }
    }
    public class CreateSocketHandler : IRequestHandler<SocketCreateCommand>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public CreateSocketHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(SocketCreateCommand request, CancellationToken cancellationToken)
        {
            context.Sockets.Add(mapper.Map<Socket>(request));
            await context.SaveChangesAsync();
            return Unit.Value;
            
        }
    }
}
