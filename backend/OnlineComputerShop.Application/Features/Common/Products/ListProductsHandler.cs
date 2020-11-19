using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Common.Products
{

    public class ProductListQuery : IRequest<IEnumerable<ProductListResponse>>
    {
        public Guid CategoryId { get; set; }
        public List<Guid> SocketIds { get; set; }
    }

    public class ProductListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }

    public class ListProductsHandler : IRequestHandler<ProductListQuery, IEnumerable<ProductListResponse>>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public ListProductsHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductListResponse>> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = null;
            if (request.SocketIds == null || request.SocketIds.Count == 0)
            {
                products = await context.Products.ToListAsync(cancellationToken);
            }
            else
            {
                products = await context.Products.Where(x => x.CategoryId == request.CategoryId && x.ProductSockets
                    .Any(ps => request.SocketIds.Contains(ps.SocketId)))
                    .ToListAsync(cancellationToken);
            }
            
            return mapper.Map<List<ProductListResponse>>(products);
        }
    }
}
