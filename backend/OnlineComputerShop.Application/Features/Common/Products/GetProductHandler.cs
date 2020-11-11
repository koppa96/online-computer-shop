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

namespace OnlineComputerShop.Application.Features.Common.Products
{
    public class ProductGetQuery : IRequest<ProductGetResponse>
    {
        public Guid ProductId { get; set; }
    }

    public class ProductGetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
        public string Category { get; set; }
        public List<PropertyValueResponse> PropertyValues { get; set; }
        public List<ProductSocketResponse> ProductSockets { get; set; }
        public List<CommentResponse> Comments { get; set; }

        public class PropertyValueResponse
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public class ProductSocketResponse
        {
            public Guid SocketId { get; set; }
            public string Name { get; set; }
        }

        public class CommentResponse
        {
            public Guid Id { get; set; }
            public string Text { get; set; }
            public int? Rating { get; set; }
            public string UserName { get; set; }
            public DateTime DateTimeOfCreation { get; set; }
        }

    }


    public class GetProductHandler : IRequestHandler<ProductGetQuery, ProductGetResponse>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public GetProductHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ProductGetResponse> Handle(ProductGetQuery request, CancellationToken cancellationToken)
        {
            var product = await context.Products
                .Include(x => x.Category)
                .Include(x => x.PropertyValues)
                    .ThenInclude(x => x.PropertyType)
                .Include(x => x.ProductSockets)
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .SingleOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);

            return mapper.Map<ProductGetResponse>(product);
        }
    }
}
