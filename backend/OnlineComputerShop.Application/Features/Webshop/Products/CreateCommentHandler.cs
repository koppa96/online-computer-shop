using AutoMapper;
using MediatR;
using OnlineComputerShop.Application.Services.Interfaces;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Webshop.Products
{
    
    public class CommentCreateCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
    }

    public class CreateCommentHandler : IRequestHandler<CommentCreateCommand>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public CreateCommentHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CommentCreateCommand request, CancellationToken cancellationToken)
        {
            context.Comments.Add(mapper.Map<Comment>(request));          
            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
