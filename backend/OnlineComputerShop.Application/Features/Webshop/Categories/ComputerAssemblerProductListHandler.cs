using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Application.Features.Webshop.Categories
{
    public class ComputerAssemblerProductListQuery : IRequest<IEnumerable<ComputerAssemblerProductListResponse>>
    {
        public Guid CategoryId { get; set; }
        public IEnumerable<ProvidedSocketQuery> ProvidedSockets { get; set; }
        
        public class ProvidedSocketQuery
        {
            public Guid SocketId { get; set; }
            public int NumberOfSocket { get; set; }
        }
    }

    public class ComputerAssemblerProductListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PricePerPiece { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<ProductSocketResponse> ProductSockets { get; set; }
        
        public class ProductSocketResponse
        {
            public Guid SocketId { get; set; } 
            public string SocketName { get; set; }
            public ProvidesUses ProvidesUses { get; set; }
            public int NumberOfSocket { get; set; }
        }
    }
    
    public class ComputerAssemblerProductListHandler : IRequestHandler<ComputerAssemblerProductListQuery, IEnumerable<ComputerAssemblerProductListResponse>>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public ComputerAssemblerProductListHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        public async Task<IEnumerable<ComputerAssemblerProductListResponse>> Handle(ComputerAssemblerProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await context.Products.Include(x => x.ProductSockets)
                    .ThenInclude(x => x.Socket)
                .Where(x => x.CategoryId == request.CategoryId)
                .ToListAsync(cancellationToken);
            
            var relevantProducts = products.Where(p => 
                    p.ProductSockets.All(x => x.ProvidesUses == ProvidesUses.Provides) ||
                    p.ProductSockets.Any(ps => ps.ProvidesUses == ProvidesUses.Uses && request.ProvidedSockets.Any(s =>
                        s.SocketId == ps.SocketId && s.NumberOfSocket >= ps.NumberOfSocket)))
                .ToList();

            return mapper.Map<List<ComputerAssemblerProductListResponse>>(relevantProducts);
        }
    }
}