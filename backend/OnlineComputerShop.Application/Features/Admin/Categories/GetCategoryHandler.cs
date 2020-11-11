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

namespace OnlineComputerShop.Application.Features.Admin.Categories
{
    public class CategoryGetQuery : IRequest<CategoryGetResponse>
    {
        public Guid Id { get; set; }
    }

    public class CategoryGetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<PropertyTypeGetResponse> PropertyTypes { get; set; }
        public List<CategorySocketGetResponse> CategorySockets { get; set; }
        
        public class PropertyTypeGetResponse
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

        }

        public class CategorySocketGetResponse
        {
            public Guid SocketId { get; set; }
            public string SocketName { get; set; }
        }
    }

    public class GetCategoryHandler : IRequestHandler<CategoryGetQuery, CategoryGetResponse>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public GetCategoryHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<CategoryGetResponse> Handle(CategoryGetQuery request, CancellationToken cancellationToken)
        {
            var category = await context.Categories
                .Include(x => x.PropertyTypes)
                .Include(x => x.CategorySockets)
                    .ThenInclude(x => x.Socket)
                .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return mapper.Map<CategoryGetResponse>(category);
        }
    }
}
