using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Webshop.Comments
{

    public class CommentEditCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
    }

    public class EditCommentHandler : IRequestHandler<CommentEditCommand>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public EditCommentHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CommentEditCommand request, CancellationToken cancellationToken)
        {
            var comment = await context.Comments.FindAsync(request.Id, cancellationToken);
            if (comment != null)
            {
                comment.Text = request.Text;
                comment.Rating = request.Rating;
            }
            else
            {
                context.Comments.Add(mapper.Map<Comment>(request));
            }

            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
