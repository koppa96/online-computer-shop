using AutoMapper;
using MediatR;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Products
{
    public class ProductEditCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
        public List<PropertyValueEditCommand> PropertyValues { get; set; }
        public List<ProductSocketEditCommand> ProductSockets { get; set; }

        public class PropertyValueEditCommand
        {
            public Guid PropertyTypeId { get; set; }
            public string Value { get; set; }
        }

        public class ProductSocketEditCommand
        {
            public Guid SocketId { get; set; }
        }
    }


    public class EditProductHandler : IRequestHandler<ProductEditCommand>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public EditProductHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(ProductEditCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);
            if (product != null)
            {
                context.PropertyValues.RemoveRange(product.PropertyValues);
                product.Name = request.Name;
                product.Price = request.Price;
                product.ProductSockets = mapper.Map<List<ProductSocket>>(request.ProductSockets);
                product.PropertyValues = mapper.Map<List<PropertyValue>>(request.PropertyValues);

            } else
            {
                context.Products.Add(mapper.Map<Product>(request));
            }

            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
