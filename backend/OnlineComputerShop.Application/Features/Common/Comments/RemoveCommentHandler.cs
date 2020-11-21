using MediatR;
using OnlineComputerShop.Application.Services.Interfaces;
using OnlineComputerShop.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Common.Comments
{
    public class CommentRemoveCommand : IRequest
    {
        public Guid Id { get; set; }

    }


    public class RemoveCommentHandler : IRequestHandler<CommentRemoveCommand>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IIdentityService identityService;

        public RemoveCommentHandler(OnlineComputerShopContext context, IIdentityService identityService)
        {
            this.context = context;
            this.identityService = identityService;
        }

        public async Task<Unit> Handle(CommentRemoveCommand request, CancellationToken cancellationToken)
        {
            var comment = await context.Comments.FindAsync(request.Id);
            context.Comments.Remove(comment);
            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
