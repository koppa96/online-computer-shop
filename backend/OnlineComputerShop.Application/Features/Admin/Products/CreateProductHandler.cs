using AutoMapper;
using MediatR;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Products
{
    public class ProductCreateCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
        public List<PropertyValueCreateCommand> PropertyValues { get; set; }
        public List<ProductSocketCreateCommand> ProductSockets { get; set; }


        public class PropertyValueCreateCommand
        {
            public Guid PropertyTypeId { get; set; }
            public string Value { get; set; }
        }

        public class ProductSocketCreateCommand
        {
            public Guid SocketId { get; set; }
        }
    }


    public class CreateProductHandler : IRequestHandler<ProductCreateCommand>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public CreateProductHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            context.Products.Add(mapper.Map<Product>(request));
            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
