using MediatR;
using OnlineComputerShop.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Products
{
    public class ProductRemoveCommand : IRequest
    {
        public Guid ProductId { get; set; }
    }

    public class RemoveProductHandler : IRequestHandler<ProductRemoveCommand>
    {
        private readonly OnlineComputerShopContext context;

        public RemoveProductHandler(OnlineComputerShopContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.ProductId);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
